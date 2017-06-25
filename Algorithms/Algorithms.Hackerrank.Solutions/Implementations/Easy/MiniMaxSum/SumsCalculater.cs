using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.Implementations.Easy.MiniMaxSum
{
    /// <summary>
    /// Solution for the challenge https://www.hackerrank.com/challenges/mini-max-sum
    /// </summary>
    public class SumsCalculater
    {
        public SumPair Calculate(IEnumerable<uint> nums)
        {
            long sum = 0;
            uint min = Int32.MaxValue;
            uint max = 0;
            foreach(var item in nums)
            {
                sum=+ item;
                if (item > max)
                {
                    max = item;
                }

                if (item < min)
                {
                    min = item;
                }
            }

            return new SumPair(sum, min, max);
        }
    }
}
