using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GHelper.Mode
{
    internal class PowerNative
    {
        // DLL Imports
        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerWriteDCValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, int AcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerWriteACValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, int AcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerReadACValueIndex(IntPtr RootPowerKey, Guid SchemeGuid, Guid SubGroupOfPowerSettingsGuid, Guid PowerSettingGuid, out int AcValueIndex);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerSetActiveScheme(IntPtr RootPowerKey, Guid SchemeGuid);

        [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
        private static extern uint PowerGetActiveScheme(IntPtr UserPowerKey, out IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        private static extern uint PowerGetEffectiveOverlayScheme(out Guid EffectiveOverlayGuid);

        [DllImport("powrprof.dll")]
        private static extern uint PowerSetActiveOverlayScheme(Guid OverlaySchemeGuid);

        // Constants
        private static readonly Guid GUID_CPU = new("54533251-82BE-4824-96C1-47B60B740D00");
        private static readonly Guid GUID_BOOST = new("BE337238-0D82-4146-A960-4F3749D470C7");
        private static readonly string POWER_SILENT = "961CC777-2547-4F9D-8174-7D86181B8A7A";
        private static readonly string POWER_BALANCED = "00000000-0000-0000-0000-000000000000";
        private static readonly string POWER_TURBO = "DED574B5-45A0-4F42-8737-46345C09C238";
        private static readonly string PLAN_BALANCED = "381B4222-F694-41F0-9685-FF5BB260DF2E";
        private static readonly string PLAN_HIGH_PERFORMANCE = "8C5E7FDA-E8BF-4A96-9A85-A6E23A8C635C";
        private static readonly string PLAN_ULTIMATE_PERFORMACE = "E9A42B02-D5DF-448D-AA00-03F14749EB61";

        private static readonly List<string> Overlays = new()
        {
            POWER_BALANCED,
            POWER_TURBO,
            POWER_SILENT
        };

        private static readonly Dictionary<string, string> PowerModes = new()
        {
            { POWER_SILENT, "Best Power Efficiency" },
            { POWER_BALANCED, "Balanced" },
            { POWER_TURBO, "Best Performance" },
            { PLAN_HIGH_PERFORMANCE, "High Performance" },
            { PLAN_ULTIMATE_PERFORMACE, "Ultimate Performance" }
        };

        // Retrieve the active power scheme GUID
        private static Guid GetActiveScheme()
        {
            PowerGetActiveScheme(IntPtr.Zero, out IntPtr activeSchemeGuidPtr);
            var activeSchemeGuid = (Guid)Marshal.PtrToStructure(activeSchemeGuidPtr, typeof(Guid));
            return activeSchemeGuid;
        }

        // Get CPU boost index
        public static int GetCPUBoost()
        {
            Guid activeSchemeGuid = GetActiveScheme();
            PowerReadACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, out int acValueIndex);
            return acValueIndex;
        }

        // Set CPU boost index
        public static void SetCPUBoost(int boost = 0)
        {
            if (boost == GetCPUBoost()) return;

            Guid activeSchemeGuid = GetActiveScheme();
            PowerWriteACValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, boost);
            PowerWriteDCValueIndex(IntPtr.Zero, activeSchemeGuid, GUID_CPU, GUID_BOOST, boost);
            PowerSetActiveScheme(IntPtr.Zero, activeSchemeGuid);
        }

        // Get the current power mode
        public static string GetPowerMode()
        {
            if (GetActiveScheme().ToString() == PLAN_ULTIMATE_PERFORMACE) return PLAN_ULTIMATE_PERFORMACE;

            PowerGetEffectiveOverlayScheme(out Guid activeScheme);
            return activeScheme.ToString();
        }

        // Set power mode
        public static void SetPowerMode(string scheme)
        {
            if (string.IsNullOrEmpty(scheme)) scheme = PLAN_BALANCED;

            if (scheme == PLAN_ULTIMATE_PERFORMACE)
            {
                SetPowerPlan(scheme);
                return;
            }

            if (Overlays.Contains(scheme))
            {
                Guid schemeGuid = new(scheme);
                PowerSetActiveOverlayScheme(schemeGuid);
            }
            else
            {
                SetPowerPlan(scheme);
            }
        }

        // Set power plan
        public static void SetPowerPlan(string scheme)
        {
            if (Overlays.Contains(scheme)) return;

            Guid schemeGuid = new(scheme);
            PowerSetActiveScheme(IntPtr.Zero, schemeGuid);
        }

        // Logger placeholder (replace with actual implementation)
        private static class Logger
        {
            public static void WriteLine(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}