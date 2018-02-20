using System;
using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions.RangeExtraction
{
    public static class IntArrayExtensions
    {
        public static IEnumerable<Range> ExtractRanges(this int[] numbers)
        {
            if (numbers.Length == 0)
            {
                yield break;
            }

            var isRange = false;
            var from = Int32.MinValue;
            for (var i = 1; i <= numbers.Length; i++)
            {
                if (numbers[i] != numbers[i - 1] + 1)
                {
                    var prevIsRange = isRange;
                    isRange = false;
                    yield return GetRange(prevIsRange, from, numbers[numbers.Length - 1]);
                }

                if (isRange)
                {
                    continue;
                }

                isRange = true;
                from = numbers[i - 1];
            }

            yield return GetRange(isRange, from, numbers[numbers.Length - 1]);
        }

        private static Range GetRange(bool isRange, int from, int value)
        {
            return isRange ? new Range(from, value) : new Range(value);
        }
    }
}
