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
    }
}