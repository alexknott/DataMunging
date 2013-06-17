using System.Collections.Generic;
using CommonLibrary;

namespace WeatherData
{
    public class WeatherDataService
    {
        private readonly IWeatherDataProvider _weatherDataProvider;
        private readonly IMinimumDifferenceCalculator _minimumDifferenceCalculator;

        public WeatherDataService(IWeatherDataProvider weatherDataProvider, IMinimumDifferenceCalculator minimumDifferenceCalculator)
        {
            _weatherDataProvider = weatherDataProvider;
            _minimumDifferenceCalculator = minimumDifferenceCalculator;
        }

        public string GetDayWithLowestTemperatureSpread(string path)
        {
            IEnumerable<Day> days = _weatherDataProvider.GetDays(path);
            
            string result = FindLowestTemperatureSpread(days);

            return result;
        }

        private string FindLowestTemperatureSpread(IEnumerable<IDifferenceCalculator> days)
        {
            string dayNumber = _minimumDifferenceCalculator.CalculateMinimumDifference(days);
            
            if (string.IsNullOrWhiteSpace(dayNumber))
                throw new LowestTemperatureSpreadException("Could not find the day is the lowest temperature spread");
            
            return dayNumber;
        }
    }
}
