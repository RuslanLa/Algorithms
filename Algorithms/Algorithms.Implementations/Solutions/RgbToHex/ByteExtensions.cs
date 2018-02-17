using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.RgbToHex
{
    public static class ByteExtensions
    {
        private static Dictionary<byte, string> _matching = new Dictionary<byte, string>()
        {
            {10, "A"},
            {11, "B"},
            {12, "C"},
            {13, "D"},
            {14, "E"},
            {15, "F"}
        };

        public static string ToHex(this byte value)
        {
            if (value == 0)
            {
                return "0";
            }

            StringBuilder s = new StringBuilder();
            return String.Join(String.Empty, GetNumbers(value).Select(ConvertNumberToHex).Reverse());
        }

        private static IEnumerable<byte> GetNumbers(byte value)
        {
            while (value != 0)
            {
                var remainder = (byte)(value % 16);
                value /= 16;
                yield return remainder;
            }
        }

        private static string ConvertNumberToHex(byte number)
        {
            if (number <= 9)
            {
                return number.ToString();
            }

            return _matching[number];
        }
    }
}
