using System;
using CommonLibrary;

namespace FootballData
{
    public class Team : IDifferenceCalculator
    {
        public string Name { get; private set; }
        public int For { get; private set; }
        public int Against { get; private set; }

        public Team(string name, int goalsFor, int goalsAgainst)
        {
            Name = name;
            For = goalsFor;
            Against = goalsAgainst;
        }

        private int CalculateGoalDifference()
        {
            return Math.Abs(For - Against);
        }

        public string Id { get { return Name; }}
        
        public int CalculateDifference()
        {
            return CalculateGoalDifference();
        }
    }
}