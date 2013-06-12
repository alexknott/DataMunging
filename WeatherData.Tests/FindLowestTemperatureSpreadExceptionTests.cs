using System;
using NUnit.Framework;

namespace WeatherData.Tests
{
    [TestFixture]
    public class FindLowestTemperatureSpreadExceptionTests
    {
        [Test]
        public void ExceptionMessageIsSet()
        {
            string exceptionMessage = "TestToMakeSureTheExceptionMessageisPopulated";
            Exception ex = new LowestTemperatureSpreadException(exceptionMessage);   

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
    }
}