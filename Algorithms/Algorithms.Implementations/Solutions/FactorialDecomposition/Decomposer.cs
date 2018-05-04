using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.FactorialDecomposition
{
    public class Decomposer
    {
        public string Decompose(int n)
        {
            if (n == 1)
            {
                return String.Empty;
            }
            var nums = Enumerable.Range(2, n - 1).ToArray();
            return String.Join(" * ",
                GetDecomposition(nums).Select(x => x.Value == 1 ? x.Key.ToString() :
                    String.Format("{0}^{1}", x.Key, x.Value)));
        }

        private static Dictionary<int, int> GetDecomposition(int[] nums)
        {
            var result = new Dictionary<int, int>();
            var last = nums.Last();
            for (int i = 2; i <= last; i++)
            {
                var count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    while (nums[j] % i == 0)
                    {
                        count++;
                        nums[j] /= i;
                    }
                }

                if (count == 0)
                {
                    continue;
                }
                result.Add(i, count);
            }

            return result;
        }
    }
}
