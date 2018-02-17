using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Algorithms.Implementations.Solutions.RgbToHex
{
    /// <summary>
    /// #50KataChallenge
    /// Solution for https://www.codewars.com/kata/513e08acc600c94f01000001/train/csharp/
    /// </summary>
    public class Rgb
    {
        public Rgb(int red, int green, int blue)
        {
            Red = ToByte(red);
            Green = ToByte(green);
            Blue = ToByte(blue);
        }
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

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
            var parts = new byte[] {Red, Green, Blue}.Select(v => v.ToHex()).Select(v => v.Length == 1 ? $"0{v}" : v);
            return String.Join(String.Empty, parts);
        }
    }
}
