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
            var lines = new string[28];
            lines[0] = "Source <a";
            lines[1] = "href=\"http://sunsite.tut.fi/rec/riku/soccer_data/tab/93_94/table.eng0.01_02.html\">sunsite.tut.fi/rec/riku/soccer_data/tab/93_94/table.eng0.01_02.html</a>";
            lines[2] = "";
            lines[3] = "<pre>";
            lines[4] = "       Team            P     W    L   D    F      A     Pts";
            lines[5] = "    1. Arsenal         38    26   9   3    79  -  36    87";
            lines[6] = "    2. Liverpool       38    24   8   6    67  -  30    80";
            lines[7] = "    3. Manchester_U    38    24   5   9    87  -  45    77";
            lines[8] = "    4. Newcastle       38    21   8   9    74  -  52    71";
            lines[9] = "    5. Leeds           38    18  12   8    53  -  37    66";
            lines[10] = "    6. Chelsea         38    17  13   8    66  -  38    64";
            lines[11] = "    7. West_Ham        38    15   8  15    48  -  57    53";
            lines[12] = "    8. Aston_Villa     38    12  14  12    46  -  47    50";
            lines[13] = "    9. Tottenham       38    14   8  16    49  -  53    50";
            lines[14] = "   10. Blackburn       38    12  10  16    55  -  51    46";
            lines[15] = "   11. Southampton     38    12   9  17    46  -  54    45";
            lines[16] = "   12. Middlesbrough   38    12   9  17    35  -  47    45";
            lines[17] = "   13. Fulham          38    10  14  14    36  -  44    44";
            lines[18] = "   14. Charlton        38    10  14  14    38  -  49    44";
            lines[19] = "   15. Everton         38    11  10  17    45  -  57    43";
            lines[20] = "   16. Bolton          38     9  13  16    44  -  62    40";
            lines[21] = "   17. Sunderland      38    10  10  18    29  -  51    40";
            lines[22] = "   -------------------------------------------------------";
            lines[23] = "   18. Ipswich         38     9   9  20    41  -  64    36";
            lines[24] = "   19. Derby           38     8   6  24    33  -  63    30";
            lines[25] = "   20. Leicester       38     5  13  20    30  -  64    28";
            lines[26] = "</pre>";
            lines[27] = "";

            return lines;
        }
    }
}
