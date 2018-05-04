using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.BuddyPairs
{
    public class PairsSearcher
    {
        public string Find(long start, long limit)
        {
            for (var i = start; i <= limit; i++)
            {
                var secondNumber = SumDivisors(GetDivisors(i), i) - 1;
                if (SumDivisors(GetDivisors(secondNumber), secondNumber) - 1 == i && secondNumber>i)
                {
                    return String.Format("({0} {1})", i, secondNumber);
                }
            }

            return "Nothing";
        }

        private IEnumerable<long> GetDivisors(long number)
        {
            for (long i = 1; i <= (long)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                }
            }
        }

        private long SumDivisors(IEnumerable<long> divisors, long number) =>
            divisors.Select(d => new
            {
                d,
                addition = number / d
            }).Where(x => x.d != x.addition).Select(x => x.d + x.addition).Sum() - number;
    }
}
