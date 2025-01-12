using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GHelper.Mode
{
    internal class PowerNative
    {
        // DLL Imports
        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerWriteDCValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, int DcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerWriteACValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, int AcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerReadACValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, out int AcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerSetActiveScheme(IntPtr RootPowerKey, Guid SchemeGuid);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerGetActiveScheme(IntPtr UserPowerKey, out IntPtr ActivePolicyGuid);

        // Constants
        private static readonly Guid GUID_CPU = new("54533251-82BE-4824-96C1-47B60B740D00");
        private static readonly Guid GUID_BOOST = new("BE337238-0D82-4146-A960-4F3749D470C7");
        private static readonly Guid GUID_LIDACTION = new("5CA83367-6E45-459F-A27B-476B1D01C936");

        // Power Modes Dictionary
        public static readonly Dictionary<string, string> PowerModes = new()
        {
            { "00000000-0000-0000-0000-000000000000", "Balanced" },
            { "381B4222-F694-41F0-9685-FF5BB260DF2E", "High Performance" },
            { "E9A42B02-D5DF-448D-AA00-03F14749EB61", "Ultimate Performance" }
        };

        // Retrieve active power scheme GUID
        private static Guid GetActiveScheme()
        {
            PowerGetActiveScheme(IntPtr.Zero, out IntPtr activeSchemeGuidPtr);
            return (Guid)Marshal.PtrToStructure(activeSchemeGuidPtr, typeof(Guid));
        }

        // Get CPU Boost index
        public static int GetCPUBoost()
        {
            Guid activeSchemeGuid = GetActiveScheme();
            PowerReadACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, out int acValueIndex);
            return acValueIndex;
        }

        // Set CPU Boost index
        public static void SetCPUBoost(int boost)
        {
            Guid activeSchemeGuid = GetActiveScheme();
            PowerWriteACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, boost);
            PowerWriteDCValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, boost);
            PowerSetActiveScheme(IntPtr.Zero, activeSchemeGuid);
        }

        // Get power mode
        public static string GetPowerMode()
        {
            return PowerModes[GetActiveScheme().ToString()];
        }

        // Set power mode
        public static void SetPowerMode(string scheme)
        {
            if (PowerModes.ContainsKey(scheme))
            {
                Guid schemeGuid = new(scheme);
                PowerSetActiveScheme(IntPtr.Zero, schemeGuid);
            }
            else
            {
                Logger.WriteLine($"Unknown power mode: {scheme}");
            }
        }

        // Get default power mode
        public static string GetDefaultPowerMode()
        {
            return PowerModes["00000000-0000-0000-0000-000000000000"];
        }

        // Get Lid Action
        public static int GetLidAction(int dummy = 0) // Overloaded with dummy parameter
        {
            Guid activeSchemeGuid = GetActiveScheme();
            PowerReadACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_LIDACTION, GUID_LIDACTION, out int lidAction);
            return lidAction;
        }

        // Set Lid Action
        public static void SetLidAction(int action, int dummy = 0) // Overloaded with dummy parameter
        {
            Guid activeSchemeGuid = GetActiveScheme();
            PowerWriteACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_LIDACTION, GUID_LIDACTION, action);
            PowerWriteDCValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_LIDACTION, GUID_LIDACTION, action);
            PowerSetActiveScheme(IntPtr.Zero, activeSchemeGuid);
        }

        // Logger placeholder
        private static class Logger
        {
            public static void WriteLine(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}