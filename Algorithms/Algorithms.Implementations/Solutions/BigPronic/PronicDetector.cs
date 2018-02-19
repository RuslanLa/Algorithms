using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.BigPronic
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/the-big-pronic-challenge/csharp
    /// </summary>
    public class PronicDetector
    {
        public bool IsPronic(long n)
        {

            if (n < 0 || n % 2 != 0)
            {
                return false;
            }
            var number = (long) Math.Floor(Math.Sqrt(n));
            return (number + 1) * number == n;
        }
    }
}
