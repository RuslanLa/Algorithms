using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.RomanNumerals
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/51b6249c4612257ac0000005/csharp
    /// </summary>
    public class RomanDecode : IEnumerable<int>
    {
        public static int Solution(string roman)
        {
            int sum = 0;
            var previous = 0;
            foreach (var num in roman.Select(GetInt).Reverse())
            {
                if (previous > num)
                {
                    sum -= num;
                    continue;
                }

                previous = num;
                sum += num;
            }

            return sum;
        }

        private static int GetInt(char roman)
        {
            switch (roman)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
