using System.Collections.Generic;
using System.Linq;
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
            _fileSystemWrapper = new Mock<FileSystemFacade>();   
            IList<string> rawDays = new List<string>();
            rawDays.Add("(Unofficial, Preliminary Data). Source: <a");
            rawDays.Add("href=\"http://www.erh.noaa.gov/er/box/dailystns.html\">www.erh.noaa.gov/er/box/dailystns.html</a>");
            rawDays.Add("");
            rawDays.Add("<pre>");
            rawDays.Add("MMU June 2002");
            rawDays.Add("");
            rawDays.Add("  Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP");
            rawDays.Add("");
            rawDays.Add("   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5");
            rawDays.Add("   2  79    63    71          46.5       0.00         330  8.7 340  23  3.3  70 28 1004.5");
            rawDays.Add("  mo  82.9  60.5  71.7    16  58.8       0.00              6.9          5.3");
            rawDays.Add("</pre>");
            rawDays.Add("");
            _fileSystemWrapper.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(rawDays.ToArray());
        }

        [Test]
        public void GetDaysReturnsEnumerableOfDays()
        {
            WeatherDataProvider weatherDataProvider = new WeatherDataProvider(_fileSystemWrapper.Object);
            var days = weatherDataProvider.GetDays("").ToArray();

            Assert.AreEqual(2, days.Length);
            Assert.AreEqual(1, days[0].DayNumber);
            Assert.AreEqual(88, days[0].Mxt);
            Assert.AreEqual(59, days[0].Mnt);
            Assert.AreEqual(2, days[1].DayNumber);
            Assert.AreEqual(79, days[1].Mxt);
            Assert.AreEqual(63, days[1].Mnt);
            
        }


    }
}
