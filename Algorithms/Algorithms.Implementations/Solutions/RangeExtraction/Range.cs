using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.RangeExtraction
{
    public class Range
    {
        public int From { get; }
        public int To { get; }

        public Range(int from, int to)
        {
            From = from;
            To = to;
        }

        public Range(int value)
        {
            From = value;
            To = value;
        }

        public override string ToString()
        {
            if (From == To)
            {
                return From.ToString();
            }

            if (From == To - 1)
            {
                return $"{From},{To}";
            }
            return $"{From}-{To}";
        }
    }
}
