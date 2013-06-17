using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballData;
using NUnit.Framework;
using WeatherData;

namespace CommonLibrary.Tests
{
    [TestFixture]
    public class MinimumDifferenceCalculatorTests
    {
        [Test]
        public void MinimumDifferenceCalculatorFindsTheLowestDifferenceInTheList()
        {
            var minimumDifferenceCalculator = new MinimumDifferenceCalculator();
            
            var listToCheck = new List<IDifferenceCalculator>();
            listToCheck.Add(GetDayItem(1, 10, 5));
            listToCheck.Add(GetDayItem(2, 20, 9));

            string smallestDiffernce = minimumDifferenceCalculator.CalculateMinimumDifference(listToCheck);

            Assert.AreEqual("1", smallestDiffernce);
        }

        private IDifferenceCalculator GetDayItem(int dayNumber, int max, int min)
        {
            var day = new Day(dayNumber, max, min);
            return day;
        }

        [Test]
        public void WhenMinimumFactorIsFirst()
        {
            var minimumDifferenceCalculator = new MinimumDifferenceCalculator();

            var listToCheck = new List<IDifferenceCalculator>();
            listToCheck.Add(GetDayItem(101, 0, 0));
            listToCheck.Add(GetDayItem(500, 20, 9));
            listToCheck.Add(GetDayItem(501, 20, 9));

            string smallestDiffernce = minimumDifferenceCalculator.CalculateMinimumDifference(listToCheck);

            Assert.AreEqual("101", smallestDiffernce);
        }

        [Test]
        public void WhenMinimumFactorIsLast()
        {
            var minimumDifferenceCalculator = new MinimumDifferenceCalculator();

            var listToCheck = new List<IDifferenceCalculator>();
            listToCheck.Add(GetDayItem(500, 20, 9));
            listToCheck.Add(GetDayItem(501, 20, 9));
            listToCheck.Add(GetDayItem(502, 20, 10));

            string smallestDiffernce = minimumDifferenceCalculator.CalculateMinimumDifference(listToCheck);

            Assert.AreEqual("502", smallestDiffernce);
        }

        [Test]
        public void WhenMinimumFactorIsInTheMiddle()
        {
            var minimumDifferenceCalculator = new MinimumDifferenceCalculator();

            var listToCheck = new List<IDifferenceCalculator>();
            listToCheck.Add(GetDayItem(500, 20, 9));
            listToCheck.Add(GetDayItem(501, 20, 11));
            listToCheck.Add(GetDayItem(502, 20, 10));

            string smallestDiffernce = minimumDifferenceCalculator.CalculateMinimumDifference(listToCheck);

            Assert.AreEqual("501", smallestDiffernce);     
        }

        [Test]
        public void WhenSecondFactorLargerThanFirst()
        {
            var minimumDifferenceCalculator = new MinimumDifferenceCalculator();

            var listToCheck = new List<IDifferenceCalculator>();
            listToCheck.Add(GetTeamItem("TeamA", 20, 9));
            listToCheck.Add(GetTeamItem("TeamB", 20, 11));
            listToCheck.Add(GetTeamItem("TeamC", 20, 21));

            string smallestDiffernce = minimumDifferenceCalculator.CalculateMinimumDifference(listToCheck);

            Assert.AreEqual("TeamC", smallestDiffernce);     
        }

        private IDifferenceCalculator GetTeamItem(string name, int gaolsFor, int goalsAgainst)
        {
            return new Team(name, gaolsFor, goalsAgainst);
        }
    }
}
