    using System;
    using System.Collections.Generic;
    using System.Linq;
/// <summary>
/// It is a full solution for
/// https://www.codewars.com/kata/rgb-to-hex-conversion/train/csharp
/// </summary>
public class Kata
{

    public static string Rgb(int r, int g, int b)
    {
        return new RgbValue(r, g, b).ToHex();
    }

    private class RgbValue
    {
        public RgbValue(int red, int green, int blue)
        {
            Red = ToByte(red);
            Green = ToByte(green);
            Blue = ToByte(blue);
        }

        private byte Red { get; }
        private byte Green { get; }
        private byte Blue { get; }

        private byte ToByte(int value)
        {
            if (value < 0)
            {
                return (byte) 0;
            }

            return value > Byte.MaxValue ? Byte.MaxValue : (byte) value;
        }

        public string ToHex()
        {
            var parts = new byte[] {Red, Green, Blue}.Select(ToHex).Select(v => v.Length == 1 ? $"0{v}" : v);
            return String.Join(String.Empty, parts);
        }

        private static Dictionary<byte, string> _matching = new Dictionary<byte, string>()
        {
            {10, "A"},
            {11, "B"},
            {12, "C"},
            {13, "D"},
            {14, "E"},
            {15, "F"}
        };

        public static string ToHex(byte value)
        {
            if (value == 0)
            {
                return "0";
            }

            return String.Join(String.Empty, GetNumbers(value).Select(ConvertNumberToHex).Reverse());
        }

        private static IEnumerable<byte> GetNumbers(byte value)
        {
            while (value != 0)
            {
                var remainder = (byte) (value % 16);
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
