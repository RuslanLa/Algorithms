using System;
using System.Linq;
using System.Text;

namespace Algorithms.Implementations.Solutions.MorseCode
{
    /// <summary>
    /// Char Code mock - related to task on codewars structure
    /// </summary>
    public static class MorseCode
    {
        public static string Get(string code)
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/decode-the-morse-code
    /// </summary>
    public static class StringExtensions
    {
        public static string Decode(string code)
        {
            return String.Join(" ", code.Split(new[] {"   "}, StringSplitOptions.None)
                .Where(w => !String.IsNullOrEmpty(w))
                .Select(w => String.Join("", w.Split(' ').Where(c => !String.IsNullOrEmpty(c)).Select(MorseCode.Get))));
        }
    }
}
