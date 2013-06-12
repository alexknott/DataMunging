using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData
{
    public class FootballDataService
    {
        private readonly ITeamFactory _teamFactory;

        public FootballDataService(ITeamFactory teamFactory)
        {
            _teamFactory = teamFactory;
        }

        public string FindTeamWithLowestGoalDifference()
        {
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
        }
    }
}
