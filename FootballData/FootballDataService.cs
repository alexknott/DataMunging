using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

namespace FootballData
{
    public class FootballDataService
    {
        private readonly ITeamFactory _teamFactory;
        private readonly IMinimumDifferenceCalculator _minimumDifferenceCalculator;

        public FootballDataService(ITeamFactory teamFactory)
        {
            _teamFactory = teamFactory;
            _minimumDifferenceCalculator = new MinimumDifferenceCalculator();
        }

        public string FindTeamWithLowestGoalDifference()
        {
            IEnumerable<Team> teams = _teamFactory.GetTeams();
            return _minimumDifferenceCalculator.CalculateMinimumDifference(teams);
            /*
            Team[] teams = _teamFactory.GetTeams();
            
            
            var smallestDifferenceTeam = new Team();

            int smallest = int.MaxValue;
            foreach (var team in teams)
            {
                if (team.Difference < smallest)
                {
                    smallestDifferenceTeam = team;
                    smallest = smallestDifferenceTeam.Difference;
                }
            }
            
            return smallestDifferenceTeam.Name;
            */
        }
    }
}
