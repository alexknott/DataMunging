using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FootballData.Tests
{
    [TestFixture]
    public class TeamTests
    {
        private Team _teamDefaultForTests;
        [SetUp]
        public void TestSetUp()
        {
            _teamDefaultForTests = new Team();
            _teamDefaultForTests.Name = "theTeamName";
            _teamDefaultForTests.For = 10;
            _teamDefaultForTests.Against = 100;
        }

        [Test]
        public void TeamNameIsSet()
        {
            Team team = new Team();
            team.Name = "theTeamName";
            Assert.AreEqual("theTeamName", team.Name);
        }

        [Test]
        public void TeamForIsSet()
        {
            Team team = new Team();
            team.For = 10;
            Assert.AreEqual(10, team.For);
        }

        [Test]
        public void TeamAgainstIsSet()
        {
            Team team = new Team();
            team.Against = 100;
            Assert.AreEqual(100, team.Against);
        }

        [Test]
        public void CalaculateDifferenceReturnsDifferenceWhenForIsGreaterThanAgainst()
        {
            Team team = new Team();
            team.For = 20;
            team.Against = 8;

            Assert.AreEqual(12, team.Difference);
        }

        [Test]
        public void CalculateDifferenceReturnsDifferenceWhenAgainstIsGreaterThanFor()
        {
            Team team = new Team();
            team.For = 5;
            team.Against = 10;

            Assert.AreEqual(5, team.Difference);
        }


    }
}
