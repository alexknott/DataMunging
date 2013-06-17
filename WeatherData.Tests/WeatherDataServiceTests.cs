using System;
using System.Collections.Generic;
using System.IO;
using CommonLibrary;
using Moq;
using NUnit.Framework;

namespace WeatherData.Tests
{
    [TestFixture]
    public class WeatherDataServiceTests
    {
        private Mock<IWeatherDataProvider> _weatherDataProviderMock;
        private IMinimumDifferenceCalculator _minimumDifferenceCalculator;
        private IList<Day> _days;

        [SetUp]
        public void TestSetUp()
        {
            _weatherDataProviderMock = new Mock<IWeatherDataProvider>();
            _days = new List<Day>();
            _days.Add(new Day(1, 88, 59));
            _days.Add(new Day(2, 89, 58));
            _days.Add(new Day(3, 59, 59));
            _days.Add(new Day(4, 90, 60));
            _weatherDataProviderMock.Setup(m => m.GetDays(It.IsAny<string>())).Returns(_days);

            _minimumDifferenceCalculator = new MinimumDifferenceCalculator();
        }


        [Test]
        [TestCase("3")]
        public void ReturnsDayNumberWithLowestTemperatureSpread(string expectedDay)
        {
            WeatherDataService weatherDataService = new WeatherDataService(_weatherDataProviderMock.Object, _minimumDifferenceCalculator);
            string result = weatherDataService.GetDayWithLowestTemperatureSpread("");

            Assert.AreEqual(expectedDay, result);
        }

        [Test]
        public void ThrowsExceptionWhenUnableToFindlowestTemperatureSpread()
        {
            _weatherDataProviderMock.Setup(m => m.GetDays(It.IsAny<string>())).Returns(new List<Day>());
            WeatherDataService weatherDataService = new WeatherDataService(_weatherDataProviderMock.Object, _minimumDifferenceCalculator);
            Assert.Throws<LowestTemperatureSpreadException>(() => weatherDataService.GetDayWithLowestTemperatureSpread(""), "Could not find the day is the lowest temperature spread");
        }

        [Test]
        public void ReturnsDayNumberWithLowestSpreadFromPhysicalFile()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weather.dat");
            WeatherDataService weatherDataService = new WeatherDataService(new WeatherDataProvider(new FileSystemFacade()), _minimumDifferenceCalculator);
            string result = weatherDataService.GetDayWithLowestTemperatureSpread(path);

            Assert.AreEqual("14", result);

        }
        
    }
}
