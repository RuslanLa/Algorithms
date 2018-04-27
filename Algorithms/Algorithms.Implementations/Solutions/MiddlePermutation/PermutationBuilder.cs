using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.MiddlePermutation
{
    public class PermutationBuilder
    {
        public string BuildMiddle(string input)
        {
            if (input.Length <= 2)
            {
                return new string(input.OrderBy(x => x).ToArray());
            }

            //if (input.Length % 2 == 0)
            //{
            //    var middle = input.Length / 2 - 1;
            //    var remainder = input.Select((v, i) => new {v, i}).Where(x => x.i != middle).Select(x => x.v).Reverse();
            //    return new string(new[] { input[middle] }.Concat(remainder).ToArray());
            //}

            //else
            //{
            //    var middle = input.Length / 3;
            //    var others = BuildMiddle(new string(input.Select((v, i) => new { v, i }).Where(x => x.i != middle).Select(x => x.v).ToArray()));
            //    return input[middle]+others;
            //}

            var nums = Enumerable.Range(0, input.Length).ToArray();
            var permutationsCount = Factorize((uint)input.Length);
            nums = FillPermutations(nums, permutationsCount/2, permutationsCount / (uint)(input.Length), 0, (uint)input.Length - 1);
            var chars = BuildChars(input.ToCharArray().OrderBy(x=>(int)x).ToArray(), nums).ToArray();
            return new string(chars);
        }

        public IEnumerable<char> BuildChars(char[] initial, int[] positions)
        {
            foreach (var position in positions)
            {
                yield return initial[position];
            }
        }

        private int[] FillPermutations(int[] permutations, BigInteger remaind, BigInteger count, uint startFrom, uint factor)
        {
            if (remaind == 1)
            {
                return permutations;
            }
            var firstValue = (ulong)((remaind-1) / count);
            if (remaind % count == 0)
            {
                return permutations.Take((int)startFrom).Concat(new[] {permutations[(ulong)startFrom + (ulong)firstValue]}).Concat(
                        permutations.Select((v, i) => new {v, i}).Skip((int)startFrom)
                            .Where(x => (ulong)x.i != startFrom + firstValue).OrderByDescending(x => x.v).Select(x => x.v))
                    .ToArray();
            }

            permutations = permutations.Take((int)startFrom).Concat(new[] {permutations[(ulong)startFrom + (ulong)firstValue]}).Concat(
                permutations.Select((v, i) => new {v, i}).Skip((int)startFrom)
                    .Where(x => (ulong)x.i != startFrom + firstValue).OrderBy(x => x.v).Select(x => x.v)).ToArray();
            return FillPermutations(permutations, remaind % count, count / factor, startFrom + 1,
                factor - 1);
        }

        private BigInteger Factorize(uint num)
        {
            if (num == 1)
            {
                return 1;
            }

            return Factorize(num - 1) * num;
        }
    }
}
