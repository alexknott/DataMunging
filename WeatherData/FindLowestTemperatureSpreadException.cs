using System;

namespace WeatherData
{
    public class LowestTemperatureSpreadException : Exception
    {
        public LowestTemperatureSpreadException(string message) : base(message)
        {
             
        }
    }
}