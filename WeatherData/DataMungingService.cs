using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData
{
    public class DataMungingService
    {
        private IWeatherDataProvider _weatherDataProvider;

        public DataMungingService(IWeatherDataProvider weatherDataProvider)
        {
            _weatherDataProvider = weatherDataProvider;
        }

        public string GetDayWithLowestTemperatureSpread(string path)
        {
            IEnumerable<Day> days = _weatherDataProvider.GetDays(path);


            string result = FindLowestTemperatureSpread(days);

            return result;
        }

        private string FindLowestTemperatureSpread(IEnumerable<Day> days)
        {
            int dayNumber = 0;
            var lowestSpread = int.MaxValue;

            foreach (var day in days)
                if ((day.Mxt - day.Mnt) < lowestSpread)
                {
                    lowestSpread = day.Spread;
                    dayNumber = day.DayNumber;
                }
            
            if (dayNumber == 0)
                throw new LowestTemperatureSpreadException("Could not find the day is the lowest temperature spread");
            
            return dayNumber.ToString();
        }
    }
}
