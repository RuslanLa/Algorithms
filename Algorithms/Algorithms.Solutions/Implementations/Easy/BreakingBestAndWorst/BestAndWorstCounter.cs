using System;
using System.Collections.Generic;

namespace Algorithms.Solutions.Implementations.Easy.BreakingBestAndWorst
{
    /// <summary>
    /// Solution for the challenge https://www.hackerrank.com/challenges/breaking-best-and-worst-records
    /// </summary>
    public class BestAndWorstCounter
    {
        public CounterResult GetResult(IEnumerable<long> records)
        {
            var min = Int64.MaxValue;
            long max = -1;
            var countMin = -1;
            var countMax = -1;
            foreach(var rec in records)
            {
                if (rec < min)
                {
                    min = rec;
                    countMin++;
                }

                if (rec > max)
                {
                    max = rec;
                    countMax++;
                }
            }

            return new CounterResult(countMin, countMax);
        }
    }
}
