using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Algorithms.Implementations.Solutions.BaseConversion
{
    /// <summary>
    /// Solution for the Kata https://www.codewars.com/kata/526a569ca578d7e6e300034e
    /// </summary>
    public class Converter
    {
        public string Convert(string input, string source, string target)
        {
            var decimalInput = ConvertToDecimal(input, source);
            return target == Alphabet.DECIMAL ? decimalInput.ToString("####") : ConvertFromDecimal(decimalInput, target);
        }

        private decimal StringToDecimal(string input) => Decimal.Parse(input, NumberStyles.Integer);

        private decimal ConvertToDecimal(string input, string source)
        {
            if (source == Alphabet.DECIMAL)
            {
                return StringToDecimal(input);
            }

            decimal result = 0;
            decimal rank = 1;
            var indexedSource = source.Select((v, i) => new {v, i}).ToDictionary(x => x.v, x => x.i);
            for (int i = input.Length - 1; i>=0; i--)
            {
                result += rank * indexedSource[input[i]];
                rank *= source.Length;
            }
            return result;
        }

        private string ConvertFromDecimal(decimal input, string target)
        {
            if (input == 0)
            {
                return target[0].ToString();
            }
            var stack = new Stack<char>();
            while (input >= 1)
            {
                stack.Push(target[(int)(input%target.Length)]);
                input = input / target.Length;
            }

            return String.Join("", stack);
        }

    }
}

