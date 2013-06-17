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
            _teamDefaultForTests = new Team("theTeamName", 100, 10);
        }

        [Test]
        public void TeamNameIsSet()
        {
            Assert.AreEqual("theTeamName", _teamDefaultForTests.Name);
        }

        [Test]
        public void TeamForIsSet()
        {
            Assert.AreEqual(100, _teamDefaultForTests.For);
        }

        [Test]
        public void TeamAgainstIsSet()
        {
            Assert.AreEqual(10, _teamDefaultForTests.Against);
        }

        [Test]
        public void CalaculateDifferenceReturnsDifferenceWhenForIsGreaterThanAgainst()
        {
            Assert.AreEqual(90, _teamDefaultForTests.CalculateDifference());
        }

        [Test]
        public void CalculateDifferenceReturnsDifferenceWhenAgainstIsGreaterThanFor()
        {
            var team = new Team("antherTeam", 5, 10);
            Assert.AreEqual(5, team.CalculateDifference());
        }
    }
}
