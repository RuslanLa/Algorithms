using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.NonBouncyNumbers
{
    /// <summary>
    /// Solution for kata https://www.codewars.com/kata/55b195a69a6cc409ba000053/csharp
    /// </summary>
    public class Counter
    {
        public BigInteger CalculateTotal(int x)
        {
            if (x == 0)
            {
                return 1;
            }

            if (x == 1)
            {
                return 10;
            }

            var increasing = GetIncreasing(x);
            var decreasing = GetDecreasing(x);
            var sum = increasing + decreasing;
            return sum - (x) * 9 - 1;
        }


        private BigInteger GetCount(int x, bool isIncreasing)
        {
            var counterArray = GetCounterArray(x, isIncreasing ? 9 : 10);
            BigInteger count = isIncreasing ? 55 : 64;
            for (int i = 1; i < x - 1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    BigInteger value = 0;
                    for (int z = j; z < 9; z++)
                    {
                        value += counterArray[i - 1, z];
                    }

                    if (!isIncreasing)
                    {
                        value += 1;
                    }
                    counterArray[i, j] = value;
                    count += value;
                }
            }

            return count;
        }

        private BigInteger GetIncreasing(int x)
        {
            return GetCount(x, true);
        }

        private BigInteger GetDecreasing(int x)
        {
            return GetCount(x, false);
        }

        private BigInteger[,] GetCounterArray(int x, int possibleCounts)
        {
            var counterArray = new BigInteger[x - 1, 9];
            for (int i = 0; i < 9; i++)
            {
                counterArray[0, i] = possibleCounts - i;
            }

            return counterArray;
        } 
    }
}
