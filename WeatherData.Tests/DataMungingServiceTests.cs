using System;
using System.Collections.Generic;
using System.IO;
using CommonLibrary;
using Moq;
using NUnit.Framework;

namespace WeatherData.Tests
{
    [TestFixture]
    public class DataMungingServiceTests
    {
        private Mock<IWeatherDataProvider> _weatherDataProviderMock;
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
        }


        [Test]
        [TestCase("3")]
        public void ReturnsDayNumberWithLowestTemperatureSpread(string expectedDay)
        {
            DataMungingService dataMungingService = new DataMungingService(_weatherDataProviderMock.Object);
            string result = dataMungingService.GetDayWithLowestTemperatureSpread("");

            Assert.AreEqual(expectedDay, result);
        }

        [Test]
        public void ThrowsExceptionWhenUnableToFindlowestTemperatureSpread()
        {
            _weatherDataProviderMock.Setup(m => m.GetDays(It.IsAny<string>())).Returns(new List<Day>());
            DataMungingService dataMungingService = new DataMungingService(_weatherDataProviderMock.Object);
            Assert.Throws<LowestTemperatureSpreadException>(() => dataMungingService.GetDayWithLowestTemperatureSpread(""), "Could not find the day is the lowest temperature spread");
        }

        [Test]
        public void ReturnsDayNumberWithLowestSpreadFromPhysicalFile()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weather.dat");
            DataMungingService dataMungingService = new DataMungingService(new WeatherDataProvider(new FileSystemWrapper()));
            string result = dataMungingService.GetDayWithLowestTemperatureSpread(path);

            Assert.AreEqual("14", result);

        }
        
    }
}
