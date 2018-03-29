using System.Linq;

namespace Algorithms.Implementations.Solutions.HammingNumbers
{
    public class Calculator
    {
        public long CalculateNth(int n)
        {
            var uglies = new long[n];
            uglies[0] = 1;
            uint lastIndex2 = 0;
            uint lastIndex3 = 0;
            uint lastIndex5 = 0;
            long nextValue2 = 2;
            long nextValue3 = 3;
            long nextValue5 = 5;

            for (uint i = 1; i < n; i++)
            {
                var minValue = Min(nextValue2, nextValue3, nextValue5);
                uglies[i] = minValue;
                if (nextValue2 == minValue)
                {
                    RememberValue(uglies, 2, ref lastIndex2, ref nextValue2);
                }

                if (nextValue3 == minValue)
                {
                    RememberValue(uglies, 3, ref lastIndex3, ref nextValue3);
                }

                if (nextValue5 == minValue)
                {
                    RememberValue(uglies, 5, ref lastIndex5, ref nextValue5);
                }
            }

            return uglies[n - 1];
        }

        private long Min(params long[] values)
        {
            return values.Min();
        }

        private static void RememberValue(long[] uglies, uint multiplicator, ref uint valueIndex, ref long nextValue)
        {
            valueIndex++;
            nextValue = uglies[valueIndex] * multiplicator;
        }
    }
}

