using System.Linq;

namespace Algorithms.Implementations.Solutions.FiboAkin
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/fibo-akin
    /// </summary>
    public class Fibkind
    {
        public static long LengthSupUK(int n, int k)
        {
            var sequence = Generate(n);
            return sequence.LongCount(x => x >= k);
        }

        public static long Comp(int n)
        {
            var sequence = Generate(n);
            return sequence.Select((v, i) => new {cur = v, prev = i == 0 ? 0 : sequence[i - 1]}).LongCount(x => x.cur < x.prev);
        }

        private static long[] Generate(int length)
        {
            var sequence = new long[length];
            sequence[0] = 1;
            sequence[1] = 1;
            for (int i = 2; i < length; i++)
            {
                sequence[i] = sequence[i - sequence[i - 1]] + sequence[i - sequence[i - 2]];
            }

            return sequence;
        }

    }
}
