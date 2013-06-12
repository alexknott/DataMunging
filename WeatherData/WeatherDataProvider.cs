using System.Collections.Generic;
using CommonLibrary;

namespace WeatherData
{
    public interface IWeatherDataProvider
    {
        IEnumerable<Day> GetDays(string path);
    }

    public class WeatherDataProvider : IWeatherDataProvider
    {
        
        private readonly FileSystemWrapper _fileSystemWrapper;

        public WeatherDataProvider(FileSystemWrapper fileSystemWrapper)
        {
            _fileSystemWrapper = fileSystemWrapper;
        }

        public virtual IEnumerable<Day> GetDays(string path)
        {
            IList<Day> days = new List<Day>();
            var rawDayLines = _fileSystemWrapper.ReadAllLines(path);

            //foreach (string rawDay in rawDayLines)
            int lineCount = WeatherDataFileConstants.FirstDataLine-1;
            while(lineCount < rawDayLines.Length-WeatherDataFileConstants.LinesToDrop)
            {
                days.Add(ParseDay(rawDayLines[lineCount]));
                lineCount++;
            }
            return days;
        }

        private Day ParseDay(string rawDay)
        {
            //var widths = new WeatherDataFileConstants();

            string tempValue = rawDay.Substring(WeatherDataFileConstants.DayColumnPosition, WeatherDataFileConstants.DayColumnWidth);
            int dayNumber = int.Parse(tempValue);

            tempValue = rawDay.Substring(WeatherDataFileConstants.MaxTemperatureColumnPosition, WeatherDataFileConstants.MaxTemperatureColumnWidth).Trim('*', ' ');
            int maxTemperature = int.Parse(tempValue);

            tempValue = rawDay.Substring(WeatherDataFileConstants.MinTemperatureColumnPosition, WeatherDataFileConstants.MinTemperatureColumnWidth).TrimEnd('*', ' ');
            int minTemperature = int.Parse(tempValue);

            return new Day(dayNumber, maxTemperature, minTemperature);
        }
    }
}