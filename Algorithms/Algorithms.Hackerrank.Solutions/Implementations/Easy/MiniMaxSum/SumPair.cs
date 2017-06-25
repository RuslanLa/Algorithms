using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.Implementations.Easy.MiniMaxSum
{
    public class SumPair
    {
        public readonly long Max;
        public readonly long Min;

        public SumPair(long sum, uint min, uint max)
        {
            Max = sum - min;
            Min = sum - max;
        }
    }
}
