using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.Multiples
{
    /// <summary>
    /// Solution for Kata
    /// </summary>
    public class MultiplesCalculator
    {
        public int SumMultiplesOf3And5(int maxMultiple)
        {
            return GetMultiples(maxMultiple, 3).Concat(GetMultiples(maxMultiple, 5)).Distinct().Sum();
        }

        private IEnumerable<int> GetMultiples(int maxMultiple, int multiplicator)
        {
            var curValue = multiplicator;
            while (curValue < maxMultiple)
            {
                var prevValue = curValue;
                curValue += multiplicator;
                yield return prevValue;
            }
        }
    }
}
