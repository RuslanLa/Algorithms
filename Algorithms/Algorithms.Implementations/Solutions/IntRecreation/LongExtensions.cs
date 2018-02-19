using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.IntRecreation
{
    public static class LongExtensions
    {
        public static long CalculateSumOfSquaredDivisors(this long number)
        {
            return GetDivisors(number).Sum(n => n * n);
        }

        private static List<long> GetDivisors(long number)
        {
            var divisors = new List<long> {number};
            for (var i = 1; i <= number / 2; i++)
            {
                if (number % i != 0)
                {
                    continue;
                }

                divisors.Add(i);
            }

            return divisors;
        }
    }
}
