using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.Implementations.Easy.BirthdayCakeCandles
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/birthday-cake-candles
    /// </summary>
    public class CandlesCalculater
    {
        public uint Calculate(IEnumerable<uint> candles)
        {
            uint max = 0;
            uint maxCount = 0;

            foreach (var height in candles)
            {
                if (height < max)
                {
                    continue;
                }

                if (height > max)
                {
                    max = height;
                    maxCount = 0;
                }
                maxCount++;
            }
            return maxCount;
        }
    }
}
