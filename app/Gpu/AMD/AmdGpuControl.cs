using GHelper.Helpers;
using System.Runtime.InteropServices;
using static GHelper.Gpu.AMD.Adl2.NativeMethods;

namespace GHelper.Gpu.AMD
{
    public class AmdGpuControl : IGpuControl, IDisposable
    {
        private readonly object _lock = new object();
        private bool _isReady;
        private nint _adlContextHandle;
        private readonly ADLAdapterInfo _internalDiscreteAdapter;
        private readonly ADLAdapterInfo? _iGPU;

        public bool IsNvidia => false;

        public string FullName => _internalDiscreteAdapter.AdapterName;

        private ADLAdapterInfo? FindByType(ADLAsicFamilyType type = ADLAsicFamilyType.Discrete)
        {
            lock (_lock)
            {
                ADL2_Adapter_NumberOfAdapters_Get(_adlContextHandle, out int numberOfAdapters);
                if (numberOfAdapters <= 0)
                    return null;

                ADLAdapterInfoArray osAdapterInfoData = new();
                int osAdapterInfoDataSize = Marshal.SizeOf(osAdapterInfoData);
                nint AdapterBuffer = Marshal.AllocCoTaskMem(osAdapterInfoDataSize);
                Marshal.StructureToPtr(osAdapterInfoData, AdapterBuffer, false);
                if (ADL2_Adapter_AdapterInfo_Get(_adlContextHandle, AdapterBuffer, osAdapterInfoDataSize)!= Adl2.ADL_SUCCESS)
                    return null;

                osAdapterInfoData = (ADLAdapterInfoArray)Marshal.PtrToStructure(AdapterBuffer, osAdapterInfoData.GetType())!;

                const int amdVendorId = 1002;

                // Determine which GPU is internal discrete AMD GPU
                ADLAdapterInfo internalDiscreteAdapter =
                    osAdapterInfoData.ADLAdapterInfo
                       .FirstOrDefault(adapter =>
                        {
                            if (adapter.Exist == 0 || adapter.Present == 0)
                                return false;

                            if (adapter.VendorID!= amdVendorId)
                                return false;

                            if (ADL2_Adapter_ASICFamilyType_Get(_adlContextHandle, adapter.AdapterIndex, out ADLAsicFamilyType asicFamilyType, out int asicFamilyTypeValids)!= Adl2.ADL_SUCCESS)
                                return false;

                            asicFamilyType = (ADLAsicFamilyType)((int)asicFamilyType & asicFamilyTypeValids);

                            return (asicFamilyType & type)!= 0;
                        });

                if (internalDiscreteAdapter.Exist == 0)
                    return null;

                return internalDiscreteAdapter;
            }
        }

        public AmdGpuControl()
        {
            if (!Adl2.Load())
                return;

            try
            {
                if (Adl2.ADL2_Main_Control_Create(1, out _adlContextHandle)!= Adl2.ADL_SUCCESS) return;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                return;
            }

            ADLAdapterInfo? internalDiscreteAdapter = FindByType(ADLAsicFamilyType.Discrete);

            if (internalDiscreteAdapter is not null)
            {
                _internalDiscreteAdapter = (ADLAdapterInfo)internalDiscreteAdapter;
                _isReady = true;
            }

            _iGPU = FindByType(ADLAsicFamilyType.Integrated);
        }

        public bool IsValid => _isReady && _adlContextHandle!= nint.Zero;

        public int? GetCurrentTemperature()
        {
            lock (_lock)
            {
                if (!IsValid)
                    return null;

                if (ADL2_New_QueryPMLogData_Get(_adlContextHandle, _internalDiscreteAdapter.AdapterIndex, out ADLPMLogDataOutput adlpmLogDataOutput)!= Adl2.ADL_SUCCESS)
                    return null;

                ADLSingleSensorData temperatureSensor = adlpmLogDataOutput.Sensors[(int)ADLSensorType.PMLOG_TEMPERATURE_EDGE];
                if (temperatureSensor.Supported == 0)
                    return null;

                return temperatureSensor.Value;
            }
        }

        // Other methods...

        private void ReleaseUnmanagedResources()
        {
            lock (_lock)
            {
                if (_adlContextHandle!= nint.Zero)
                {
                    ADL2_Main_Control_Destroy(_adlContextHandle);
                    _adlContextHandle = nint.Zero;
                    _isReady = false;
                }
            }
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~AmdGpuControl()
        {
            ReleaseUnmanagedResources();
        }
    }
}