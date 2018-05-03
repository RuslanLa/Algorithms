using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.PackingABackpack
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/5a51717fa7ca4d133f001fdf
    /// (Knapsack problem without repititions)
    /// </summary>
    public class Packer
    {
        public int GetMaxBagScore(int[] scores, int[] weight, int capacity)
        {
            var maxScores = new int[capacity];
            var usedForCapacities = new List<int>[capacity]; 
            for (int i = 0; i < capacity; i++)
            {
                var maxScore = i == 0 ? 0 : maxScores[i - 1];
                var usedThings = i == 0 ? new List<int>(){} : usedForCapacities[i - 1]; 
                for (int j = 0; j < scores.Length; j++)
                {
                    var remainWeight = i + 1 - weight[j];
                    if (remainWeight < 0 || (remainWeight != 0 && usedForCapacities[remainWeight-1].Contains(j)))
                    {
                        continue;
                    }

                    var curScore = (remainWeight==0?0:maxScores[remainWeight-1]) + scores[j];
                    if (curScore > maxScore)
                    {
                        maxScore = curScore;
                        usedThings = remainWeight == 0
                            ? new List<int>() {j}
                            : usedForCapacities[remainWeight - 1].Concat(new[] {j}).ToList();
                    }

                }

                maxScores[i] = maxScore;
                usedForCapacities[i] = usedThings;
            }

            return maxScores[capacity-1];
        }
    }
}
