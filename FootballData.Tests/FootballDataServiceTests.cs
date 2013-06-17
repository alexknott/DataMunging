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

        private Team GetTeamItem(string name, int gaolsFor, int goalsAgainst)
        {
            return new Team(name, gaolsFor, goalsAgainst);
        }

        [Test]
        public void FindTeamWithLowestGoalDifferenceUsingTheRealDataFile()
        {
            var footballDataService = new FootballDataService(new TeamFactory(new FileSystemFacade()));
            string teamWithLowestGoalDifference = footballDataService.FindTeamWithLowestGoalDifference();
            Assert.AreEqual("Aston_Villa", teamWithLowestGoalDifference);
        }


        [Test]
        public void WhenOnlyOneTeamTheTeamIsReturned()
        {
            List<Team> teams = new List<Team>();
            teams.Add(GetTeamItem("teamA", 10, 5));
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);
        }

        [Test]
        public void WhenTwoTeamsTheCorrectTeamIsReturned()
        {
            List<Team> teams = new List<Team>();
            teams.Add(GetTeamItem("teamA", 10, 5 ));
            teams.Add(GetTeamItem("teamB", 15, 5 ));
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);        
        }

        [Test]
        public void WhenLowestTeamComesFirstFindTeamReturnsCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(GetTeamItem("teamA", 2, 1));
            teams.Add(GetTeamItem("teamB", 10, 5 ));
            teams.Add(GetTeamItem("teamC", 15, 5 ));
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamA", teamWithLowestGoalDiff);         
        }

        [Test]
        public void WhenLowestTeamIsLastFindTeamFindTheCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(GetTeamItem("teamA", 9, 1 ));
            teams.Add(GetTeamItem("teamB", 2, 1 ));
            teams.Add(GetTeamItem("teamC", 1, 1 ));
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamC", teamWithLowestGoalDiff);   
        }

        [Test]
        public void WhenLowestTeamIsInTheMiddleFindTeamReturnsTheCorrectTeam()
        {
            List<Team> teams = new List<Team>();
            teams.Add(GetTeamItem("teamA", 9, 1 ));
            teams.Add(GetTeamItem("teamB", 9, 2 ));
            teams.Add(GetTeamItem("teamC", 2, 1 ));
            teams.Add(GetTeamItem("teamD", 7, 11 ));
            _teamFactoryMock.Setup(m => m.GetTeams()).Returns(teams.ToArray());

            var footballDataService = new FootballDataService(_teamFactoryMock.Object);
            string teamWithLowestGoalDiff = footballDataService.FindTeamWithLowestGoalDifference();

            Assert.AreEqual("teamC", teamWithLowestGoalDiff);          
        }
    }
}
