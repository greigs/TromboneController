using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TromboneControl
{
    public static class UserState
    {
        public static bool ControlMouse { get; set; } = false;
        public static float AudioTriggerPercentageThreshold { get; set; } = 0.2f;
        public static bool WavInEnabled { get; internal set; } = false;
        public static bool ASIOEnabled { get; internal set; } = true;
    }
}
