using GHelper.Mode;

namespace GHelper.Fan
{
    public enum AsusFan
    {
        CPU,
        GPU,
        Mid,
        XGM
    }

    public enum FanSpeedUnit
    {
        RPM,
        Percentage
    }

    public class FanSensorControl
    {
        // Constants
        private const int DEFAULT_FAN_MIN = 18;
        private const int DEFAULT_FAN_MAX = 58;
        private const int XGM_FAN_MAX = 72;
        private const int INADEQUATE_MAX = 104;
        private const int FAN_COUNT = 3;

        // Fields
        private readonly Fans _fansForm;
        private readonly ModeControl _modeControl;
        private static int?[] _measuredMax;
        private static int _sameCount = 0;
        private static System.Timers.Timer _timer;
        private static int?[] _fanMax;
        private static bool? _fanRpm;

        // Constructors
        public FanSensorControl(Fans fansForm, ModeControl modeControl)
        {
            _fansForm = fansForm;
            _modeControl = modeControl;
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        // Methods
        private static int?[] InitFanMax()
        {
            int?[] defaultMax = GetDefaultMax();
            return new int?[]
            {
                AppConfig.Get("fan_max_" + (int)AsusFan.CPU, defaultMax[(int)AsusFan.CPU]),
                AppConfig.Get("fan_max_" + (int)AsusFan.GPU, defaultMax[(int)AsusFan.GPU]),
                AppConfig.Get("fan_max_" + (int)AsusFan.Mid, defaultMax[(int)AsusFan.Mid])
            };
        }

        private static int[] GetDefaultMax()
        {
            // Use a dictionary to map models to default fan max values
            var modelToFanMax = new Dictionary<string, int[]>
            {
                {"GA401I", new int[] { 78, 76, DEFAULT_FAN_MAX }},
                {"GA401", new int[] { 71, 73, DEFAULT_FAN_MAX }},
                {"GA402", new int[] { 55, 56, DEFAULT_FAN_MAX }},
                // ...
            };

            if (modelToFanMax.TryGetValue(AppConfig.Model, out int[] fanMax))
            {
                return fanMax;
            }

            return new int[] { DEFAULT_FAN_MAX, DEFAULT_FAN_MAX, DEFAULT_FAN_MAX };
        }

        public static int GetFanMax(AsusFan device)
        {
            if (device == AsusFan.XGM) return XGM_FAN_MAX;

            if (_fanMax[(int)device] < 0 || _fanMax[(int)device] > INADEQUATE_MAX)
                SetFanMax(device, DEFAULT_FAN_MAX);

            return _fanMax[(int)device];
        }

        public static void SetFanMax(AsusFan device, int value)
        {
            _fanMax[(int)device] = value;
            AppConfig.Set("fan_max_" + (int)device, value);
        }

        public static bool FanRpm
        {
            get { return _fanRpm; }
            set
            {
                AppConfig.Set("fan_rpm", value ? 1 : 0);
                _fanRpm = value;
            }
        }

        public static string FormatFan(AsusFan device, int value)
        {
            if (value < 0) return null;

            if (value > GetFanMax(device) && value <= INADEQUATE_MAX) SetFanMax(device, value);

            if (FanRpm)
                return Properties.Strings.FanSpeed + ": " + (value * 100).ToString() + "RPM";
            else
                return Properties.Strings.FanSpeed + ": " + Math.Min(Math.Round((float)value / GetFanMax(device) * 100), 100).ToString() + "%"; // relatively to max RPM
        }

        public void StartCalibration()
        {
            _measuredMax = new int[] { 0, 0, 0 };
            _timer.Enabled = true;

            for (int i = 0; i < FAN_COUNT; i++)
                AppConfig.Remove("fan_max_" + i);

            Program.acpi.DeviceSet(AsusACPI.PerformanceMode, AsusACPI.PerformanceTurbo, "ModeCalibration");

            for (int i = 0; i < FAN_COUNT; i++)
                Program.acpi.SetFanCurve((AsusFan)i, new byte[] { 20, 30, 40, 50, 60, 70, 80, 90, 100, 100,