using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherData
{
    public static class WeatherDataFileConstants
    {
        public static int DayColumnPosition { get { return 0; } }
        public static int DayColumnWidth { get { return 5; }}

        public static int MaxTemperatureColumnPosition { get { return DayColumnWidth; } }
        public static int MaxTemperatureColumnWidth { get { return 6; }}

        public static int MinTemperatureColumnPosition { get { return DayColumnWidth+MaxTemperatureColumnWidth; } }
        public static int MinTemperatureColumnWidth { get { return 6; } }

        public static int FirstDataLine { get { return 9; } }
        public static int LinesToDrop { get { return 3; } }
    }
}
