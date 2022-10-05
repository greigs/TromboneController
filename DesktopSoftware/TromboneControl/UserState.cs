namespace TromboneControl
{
    public static class UserState
    {
        public static float AudioTriggerPercentageThreshold { get; set; } = Settings.Default.AudioTriggerPercentageThreshold;
        public static int MicSensitivitySliderValue { get; set; } = Settings.Default.MicSensitivitySliderValue;
        public static int MouseMoveMultiplier { get; set; } = Settings.Default.MouseMoveMultiplier;
        public static bool WavInEnabled { get; set; } = !Settings.Default.UseASIO;
        public static bool ASIOEnabled { get; set; } = Settings.Default.UseASIO;
        public static bool ControlMouse { get; set; } = false;
        public static string ComPortName { get; set; }
        public static bool ComPortOpened { get; set; } = false;
    }
}
