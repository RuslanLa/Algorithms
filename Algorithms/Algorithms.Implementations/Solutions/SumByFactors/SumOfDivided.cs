using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.SumByFactors
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/54d496788776e49e6b00052f/train/csharp
    /// Class name and entry method name was inherited from the kata
    /// </summary>
    public class SumOfDivided
    {
        public static string sumOfDivided(int[] lst)
        {
            Dictionary<int, int> primeFactors = new Dictionary<int, int>();
            foreach (var number in lst)
            {
                FillPrimeFactorsWithNumDivision(number, primeFactors);
            }

            return String.Join("", primeFactors.OrderBy(x => x.Key).Select(x => $"({x.Key} {x.Value})"));
        }

        private static void FillPrimeFactorsWithNumDivision(int number, Dictionary<int, int> primeFactors)
        {
            var initialValue = number;
            var absNumber = number > 0 ? number : -number;
            for (int i = 2; i <= absNumber / 2; i++)
            {
                var isFactor = false;
                while (number % i == 0)
                {
                    number = number / i;
                    isFactor = true;
                }

                if (!isFactor)
                {
                    continue;
                }

                AddFactor(initialValue, i, primeFactors);
            }

            if (number == initialValue)
            {
                AddFactor(number, absNumber, primeFactors);
            }
        }

        private static void AddFactor(int number, int factor, Dictionary<int, int> primeFactors)
        {
            if (!primeFactors.ContainsKey(factor))
            {
                primeFactors[factor] = 0;
            }

            primeFactors[factor] = primeFactors[factor] + number;
        }
    }
}
