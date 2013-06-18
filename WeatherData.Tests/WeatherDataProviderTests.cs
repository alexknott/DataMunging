using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CommonLibrary;
using Moq;
using NUnit.Framework;

namespace WeatherData.Tests
{
    [TestFixture]
    public class WeatherDataProviderTests
    {
        private Mock<FileSystemFacade> _fileSystemWrapper;

        [SetUp]
        public void TestSetUp()
        {
            var rawDays = new List<string>();
            var streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("WeatherData.Tests.Resources.weather.dat"));
            while (!streamReader.EndOfStream)
                rawDays.Add(streamReader.ReadLine());

            _fileSystemWrapper = new Mock<FileSystemFacade>();   
            _fileSystemWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(rawDays.ToArray());
        }

        [Test]
        public void GetDaysReturnsEnumerableOfDays()
        {
            WeatherDataProvider weatherDataProvider = new WeatherDataProvider(_fileSystemWrapper.Object);
            var days = weatherDataProvider.GetDays("").ToArray();

            Assert.AreEqual(29, days.Length);
            Assert.AreEqual(1, days[0].DayNumber);
            Assert.AreEqual(88, days[0].Mxt);
            Assert.AreEqual(59, days[0].Mnt);
            Assert.AreEqual(2, days[1].DayNumber);
            Assert.AreEqual(79, days[1].Mxt);
            Assert.AreEqual(63, days[1].Mnt);
        }
    }
}
