using System;

namespace FootballData
{
    public class Team
    {
        public string Name { get; set; }
        public int For { get; set; }
        public int Against { get; set; }

        public int Difference { get { return CalculateGoalDifference(); } }

        private int CalculateGoalDifference()
        {
            //return For - Against;
            return Math.Abs(For - Against);
        }
    }
}