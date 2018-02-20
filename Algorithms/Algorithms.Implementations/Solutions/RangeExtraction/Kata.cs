using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/51ba717bb08c1cd60f00002f/csharp
/// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
/// There is more suitable for unit-testing class - IntArrayExtensions
/// </summary>
public class RangeExtraction
{
    private class Range
    {
        private int From { get; }
        private int To { get; }

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
    private static IEnumerable<Range> ExtractRanges(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            yield break;
        }

        var isRange = false;
        var from = Int32.MinValue;
        for (var i = 1; i <= numbers.Length-1; i++)
        {
            if (numbers[i] != numbers[i - 1] + 1)
            {
                var prevIsRange = isRange;
                isRange = false;
                yield return GetRange(prevIsRange, from, numbers[i - 1]);
            }

            if (isRange)
            {
                continue;
            }

            isRange = true;
            from = numbers[i-1];
        }

        yield return GetRange(isRange, from, numbers[numbers.Length - 1]);
    }

    private static Range GetRange(bool isRange, int from, int value)
    {
        return isRange ? new Range(from, value) : new Range(value);
    }
    public static string Extract(int[] args)
    {

        var range = ExtractRanges(args);
        return String.Join(",", range.Select(r=>r.ToString()));
    }
}