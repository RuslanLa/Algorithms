using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.TwiceLinear
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/twice-linear
    /// </summary>
    public class Sequence
    {
        public int GetNth(int n)
        {
            var sequence = new List<int>(n) { 1 };
            var twiceIndex = 0;
            var tripleIndex = 0;
            while (sequence.Count <= n)
            {
                var twice = sequence[twiceIndex] * 2 + 1;
                var tripple = sequence[tripleIndex] * 3 + 1;
                if (twice == tripple)
                {
                    tripleIndex++;
                }

                if (twice <= tripple)
                {
                    twiceIndex++;
                    sequence.Add(twice);
                    continue;
                }

                tripleIndex++;
                sequence.Add(tripple);
            }

            return sequence.Last();
        }
    }
}
