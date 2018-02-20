using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Implementations.Solutions.IntRecreation;

namespace Algorithms.Implementations.Solutions.IntRecreation
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/integers-recreation-one/train/csharp
    /// Class name and method signature is inherited from codewars solution
    /// </summary>
    public class SumSquaredDivisors
    {
        public static string ListSquared(long m, long n)
        {
            return $"[{String.Join(",", CalculateListSquared(m, n).Select(x=>$"[{String.Join(",",x)}]"))}]";
        }

        public static List<long[]> CalculateListSquared(long m, long n)
        {
            var results = new List<long[]>();
            for (var i = m; i <= n; i++)
            {
                var sum = i.CalculateSumOfSquaredDivisors();
                if (Math.Sqrt(sum) % 1 != 0)
                {
                    continue;
                }

                results.Add(new []{i, sum});
            }

            return results;
            // your code
        }
    }
}
