using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions
{
    /// <summary>
    /// Minimum number of swaps required to sort an array calculator
    /// Given an array of n distinct elements, find the minimum number of swaps required to sort the array.
    /// </summary>
    public class SortSwapsCountCalculator
    {
        public int Calculate(int[] array)
        {
            var sorted = array.Select((v, i) => new KeyValuePair<int,int>(i, v)).OrderBy(x => x.Value).ToList();
            var visited = new bool[array.Length];
            var swapsCount = 0;
            for (var i = 0; i < array.Length; i++)
            {
                if (visited[i] || sorted[i].Key == i)
                {
                    continue;
                }

                swapsCount += CalculateCycleSizeAndMarkVisited(sorted, visited, i) - 1;
            }

            return swapsCount;
        }


        public int CalculateCycleSizeAndMarkVisited(IList<KeyValuePair<int, int>> sorted, bool[] visited, int curIndex)
        {
            var cycleSize = 0;
            while (!visited[curIndex])
            {
                visited[curIndex] = true;
                var prevIndex = curIndex;
                curIndex = sorted[curIndex].Key;
                if (sorted[curIndex].Value != sorted[prevIndex].Value)
                {
                    cycleSize++;
                }
            }
            return cycleSize;
        }
    }
}
