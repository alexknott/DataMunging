using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Moq;
using NUnit.Framework;

namespace FootballData.Tests
{
    [TestFixture]
    public class FootballDataServiceTests
    {

        private Mock<ITeamFactory> _teamFactoryMock;

        [SetUp]
        public void TestSetUp()
        {
            _teamFactoryMock = new Mock<ITeamFactory>();
        }

        [Test]
        public void FindTeamWithLowestGoalDifferenceUsingTheRealDataFile()
        {
            var footballDataService = new FootballDataService(new TeamFactory(new FileSystemWrapper()));
            string teamWithLowestGoalDifference = footballDataService.FindTeamWithLowestGoalDifference();
            Assert.AreEqual("Aston_Villa", teamWithLowestGoalDifference);
        }


        [Test]
        public void WhenOnlyOneTeamTheTeamIsReturned()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team {Name = "teamA", For = 10, Against = 5});
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);
        }

        [Test]
        public void WhenTwoTeamsTheCorrectTeamIsReturned()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team { Name = "teamA", For = 10, Against = 5 });
            teams.Add(new Team { Name = "teamB", For = 15, Against = 5 });
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);        
        }

        [Test]
        public void WhenLowestTeamComesFirstFindTeamReturnsCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team { Name = "teamA", For = 2, Against = 1 });
            teams.Add(new Team { Name = "teamB", For = 10, Against = 5 });
            teams.Add(new Team { Name = "teamC", For = 15, Against = 5 });
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);         
        }

        [Test]
        public void WhenLowestTeamIsLastFindTeamFindTheCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team { Name = "teamA", For = 9, Against = 1 });
            teams.Add(new Team { Name = "teamB", For = 2, Against = 1 });
            teams.Add(new Team { Name = "teamC", For = 1, Against = 1 });
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamC", teamWithLowestGoalDiff);   
        }

        [Test]
        public void WhenLowestTeamIsInTheMiddleFindTeamReturnsTheCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team { Name = "teamA", For = 9, Against = 1 });
            teams.Add(new Team { Name = "teamB", For = 9, Against = 2 });
            teams.Add(new Team { Name = "teamC", For = 2, Against = 1 });
            teams.Add(new Team { Name = "teamD", For = 7, Against = 11 });
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamC", teamWithLowestGoalDiff);          
        }
    }
}
