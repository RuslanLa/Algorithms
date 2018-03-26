using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.Esolang.MiniString
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/586dd26a69b6fd46dd0000c0
    /// </summary>
    public static class Interpreter
    {
        public static string Execute(string input)
        {
            var bytes = MapAggregate(input.Split('.').Select(part => part.Count(character => character == '+'))).ToArray();
            return String.Join("",
                bytes.Take(bytes.Length-1));
        }

        private static IEnumerable<char> MapAggregate(IEnumerable<int> plusesCount)
        {
            byte cellValue = 0;
            foreach (var count in plusesCount)
            {
                cellValue = (byte)(cellValue + count);
                yield return (char) cellValue;
            }
        }
    }
}
