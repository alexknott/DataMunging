using System;
using CommonLibrary;
using NUnit.Framework;

namespace WeatherData.Tests
{
    [TestFixture]
    public class DayTests
    {
        [Test]
        public void DayIsContructedCorrectly()
        {
            int dayNumber = 1;
            int mxt = 88;
            int mnt = 59;

            Day day = new Day(dayNumber, mxt, mnt);

            Assert.AreEqual(dayNumber, day.DayNumber);
            Assert.AreEqual(mxt, day.Mxt);
            Assert.AreEqual(mnt, day.Mnt);
        }

        [Test]
        public void DayImplementsIDifferenceCalculator()
        {
            Day day = new Day(1, 10, 5);

            IDifferenceCalculator differenceCalculator = new Day(1, 10, 5);
            Assert.AreEqual(5, differenceCalculator.CalculateDifference());
            Assert.AreEqual("1", differenceCalculator.Id);
        }
    }
}