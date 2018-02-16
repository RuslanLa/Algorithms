using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Solutions.DivisibleSumPairs
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/divisible-sum-pairs
    /// </summary>
    public class WaysCounter
    {
        private readonly byte[] _arr;

        public WaysCounter(byte[] arr)
        {
            _arr = arr;
        }

        public int Count(byte k)
        {
            if (k == 1)
            {
                return GetPairsCount(_arr.Length);
            }

            var helper = GetRankCounts(k);
            var sum = 0;
            for (var i = 0; i <= k / 2; i++)
            {
                var j = k - i;
                if (j == i||i==0)
                {
                    sum += GetPairsCount(helper[i]);
                    continue;
                }
                sum += helper[i] * helper[j];
            }

            return sum;
        }

        private int GetPairsCount(int count)
        {
            return ((count - 1) * (count)) / 2;
        }

        private int[] GetRankCounts(byte k)
        {
            var helper = new int[k];

            foreach (var item in GetRanks(k).GroupBy(r => r).Select(g => new { count = g.Count(), rank = g.Key }))
            {

                helper[item.rank] = item.count;
            }

            return helper;
        }

        private IEnumerable<int> GetRanks(byte k)
        {
            foreach(var el in _arr)
            {
                yield return el % k;
            }
        }
    }
}
