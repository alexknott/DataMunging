using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CommonLibrary;
using Moq;
using NUnit.Framework;

namespace FootballData.Tests
{
    [TestFixture]
    public class TeamCollectionFactoryTests
    {
        private string[] _linesForDefaultTests;
        private Mock<FileSystemFacade> _fileSystemWrapperMock;

        [SetUp]
        public void TestSetUp()
        {
            _linesForDefaultTests = DummyTestCollection();
            _fileSystemWrapperMock = new Mock<FileSystemFacade>();
            _fileSystemWrapperMock.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(_linesForDefaultTests);
        }

        [Test]
        public void GetTeamsReturnsAnArrayOfTeams()
        {
            var teamFactory = new TeamFactory(_fileSystemWrapperMock.Object);
            var teams = teamFactory.GetTeams();
            Assert.AreEqual(20, teams.Length);
        }

        [TestCase(0, "Arsenal", 79, 36)]
        [TestCase(10, "Southampton", 46, 54)]
        [TestCase(19, "Leicester", 30, 64)]
        public void TeamsInGetTeamArrayContainsCorrectValuesByArrayIndex(int arrayIndex, string expectedName, int expectedGoalsFor, int expectedGoalsAgainst)
        {
            var teamFactory = new TeamFactory(_fileSystemWrapperMock.Object);
            var teams = teamFactory.GetTeams();
            Assert.AreEqual(expectedName, teams[arrayIndex].Name);  
            Assert.AreEqual(expectedGoalsFor, teams[arrayIndex].For);
            Assert.AreEqual(expectedGoalsAgainst, teams[arrayIndex].Against);
        }



        public string[] DummyTestCollection()
        {
            var testFile = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("FootballData.Tests.Resources.football.dat"));
            var lines = new List<string>();

            while(!testFile.EndOfStream)
                lines.Add(testFile.ReadLine());

            return lines.ToArray();
        }
    }
}
