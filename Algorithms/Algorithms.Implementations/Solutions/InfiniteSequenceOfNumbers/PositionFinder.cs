using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.InfiniteSequenceOfNumbers
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/the-position-of-a-digital-string-in-a-infinite-digital-string
    /// Pass tests only partly
    /// </summary>
    public class PositionFinder
    {
        public long Find(string sequence)
        {
            var digits = sequence.Select(Char.GetNumericValue).Select(x=>(int)x).ToArray();
            if (IsOrdered(digits))
            {
                return GetPosition(digits[0]);
            }

            foreach (var chunkSize in Enumerable.Range(1, digits.Length))
            {
                var result = ChunkLeftToRight(sequence, chunkSize) ?? ChunkRightToLeft(sequence, chunkSize);
                if (result.HasValue)
                {
                    return result.Value;
                }
            }

            return GetPosition(AggregateDigits(digits));
        }

        private int ToInteger(char[] value) => AggregateDigits(value.Select(Char.GetNumericValue).Select(x => (int) x));

        private int AggregateDigits(IEnumerable<int> digits) => digits.Aggregate((curValue, digit) => curValue * 10 + digit);

        private long? ChunkLeftToRight(string input, int chunkSize)
        {
            var part = String.Join("", input.Take(chunkSize).ToArray());

            if (input[0] == '0')
            {
                for (var i = 1; i <= 9; i++)
                {
                    var value = $"{i}{part}";
                    if (TestAChunk(input, value, true))
                    {
                        return GetPosition(ToInteger(value.ToCharArray()), 1);
                    }
                }

                return null;
            }

            long firstPosition = Int64.MaxValue;
            long secondPosition = Int64.MaxValue;
            if (TestAChunk(input, part))
            {
                firstPosition = GetPosition(ToInteger(part.ToCharArray()));
            }

            for (var i = 1; i < input.Length - chunkSize; i++)
            {
                var number = String.Join("", input.Skip(chunkSize).Take(i).Concat(part).ToArray());
                if (TestAChunk(input, number, true))
                {
                    secondPosition =  GetPosition(ToInteger(number.ToCharArray()), i);
                }
            }

            var minPos = Math.Min(firstPosition, secondPosition);
            return minPos == Int64.MaxValue ? (long?)null : minPos;
        }

        private long? ChunkRightToLeft(string input, int chunkSize)
        {
            var part = ToInteger(String.Join("", input.Skip(input.Length - chunkSize))
                .ToCharArray());
            if (part == 0)
            {
                return null;
            }
            var newString = $"{part - 1}{part}";
            if (newString.EndsWith(input))
            {
                return GetPosition(part - 1, newString.IndexOf(input));
            }

            return null;
        }

        private bool IsOrdered(int[] digits)
        {
            for (var i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] != digits[i]-1)
                {
                    return false;
                }
            }

            return true;
        }

        private long GetPosition(int number, int offset=0)
        {
            var count = 9;
            var countBefore = 0;
            var rank = 1;
            var numbersCount = 0;
            foreach (var unused in GetDigits(number))
            {
                numbersCount += count;
                countBefore += (count*rank); //189
                count *= 10; //900
                rank++; //3
            }

            return countBefore + (number - numbersCount) * rank + offset - rank;
        }

        private IEnumerable<int> GetDigits(int number)
        {
            while (number>9)
            {
                var digit = number % 10;
                number = number / 10;
                yield return digit;
            }
        }

        private bool TestAChunk(string sequence, string value, bool prefixed= false)
        {
            var number = ToInteger(value.ToCharArray());
            var numbersCount = sequence.Length / value.Length;
            var newString = numbersCount > 1
                ? String.Join("",
                    Enumerable.Range(0, numbersCount).Select(x => number + x))
                : $"{number}{number + 1}";
            return prefixed
                ? String.Join("", newString.Skip(1).Take(newString.Length - 1)).StartsWith(sequence) :
                newString.StartsWith(sequence);
        }
    }
}
