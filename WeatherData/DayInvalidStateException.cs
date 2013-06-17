using System;

namespace WeatherData
{
    public class DayInvalidStateException : Exception
    {
        public DayInvalidStateException(string message) : base(message)
        {
            
        }
    }
}