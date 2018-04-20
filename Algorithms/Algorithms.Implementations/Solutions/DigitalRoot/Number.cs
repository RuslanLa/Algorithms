using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.DigitalRoot
{
    public class Number
    {
        public int DigitalRoot(long n)
        {
            while (n > 9)
            {
                n = GetDigits(n).Sum();
            }

            return (int)n;
        }

        private IEnumerable<int> GetDigits(long n)
        {
            while (n!=0)
            {
                var remainder = (int)(n % 10);
                n /= 10;
                yield return remainder;
            }
        }
    }
}
