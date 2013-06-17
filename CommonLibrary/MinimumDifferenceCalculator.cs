using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IMinimumDifferenceCalculator
    {
        string CalculateMinimumDifference(IEnumerable<IDifferenceCalculator> listToCheck);
    }

    public class MinimumDifferenceCalculator : IMinimumDifferenceCalculator
    {
        public string CalculateMinimumDifference(IEnumerable<IDifferenceCalculator> listToCheck)
        {
            int lowestValue = int.MaxValue;
            string result = string.Empty;
            foreach (var item in listToCheck)
            {
                if (item.CalculateDifference() < lowestValue)
                {
                    lowestValue = item.CalculateDifference();
                    result = item.Id;
                }
            }
            return result;
        }
    }

    public interface IDifferenceCalculator
    {
        string Id { get; }
        int CalculateDifference();
    }
}
