using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.UnknownDigit
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/find-the-unknown-digit
    /// TODO: Refactor it:
    /// TODO: 1) Handle case when there is no '?' sign on the right side of the expression
    /// TODO: 2) Beautify it. There are a lot of responsibilities of DigitCalculator,
    /// TODO: especially method CalculateExpression looks two ugly, cause handles too a lot responsibilities.  
    /// </summary>
    public class DigitCalculator
    {
        public int Calculate(string input)
        {
            var splitted = input.Split('=');
            if (splitted.Length < 2)
            {
                return -1;
            }

            var unique = Enumerable.Range(0, 10).Where(x => !input.Contains(x.ToString()));
            foreach (byte i in unique)
            {
                var expression = CalculateExpression(FillUnknowDigit(splitted[0], i));
                int expectedResult;
                if (!ToInteger(FillUnknowDigit(splitted[1], i), out expectedResult))
                {
                    continue;
                }
                if (expression == expectedResult)
                {
                    return i;
                }
            }

            return -1;
        }

        private string FillUnknowDigit(string input, byte d)
        {
            return input.Replace("?", d.ToString());
        }

        private int? CalculateExpression(string input)
        {
            var i = 0;
            var summands = new List<int>();
            var isMinus = false;
            int? number = null;
            var isMultiply = false;
            while (i < input.Length)
            {
                if (input[i] == '-')
                {
                    if (!isMultiply && number.HasValue)
                    {
                        summands.Add(number.Value);
                        number = null;
                    }

                    isMinus = !isMinus;
                    i++;
                    continue;
                }
                if (input[i] == '*')
                {
                    isMultiply = true;
                    i++;
                    continue;
                }

                if (input[i] == '+')
                {
                    summands.Add(number.Value);
                    number = null;
                    i++;
                    continue;
                }

                if (Char.IsDigit(input[i]))
                {
                    int value;
                    if (!ToInteger(input, ref i, out value))
                    {
                        return null;
                    }
                    value = value * (isMinus ? -1 : 1);
                    if (isMultiply)
                    {
                        if (!number.HasValue)
                        {
                            throw new Exception("unexpected value");
                        }
                        value = number.Value * value;
                    }

                    number = value;
                    isMultiply = false;
                    isMinus = false;
                    continue;
                }

                i++;
            }

            return summands.Sum(x => x) + (number ?? 0);
        }

        private bool ToInteger(string input, out int result)
        {
            int i = 0;
            return ToInteger(input, ref i, out result);
        }

        private bool ToInteger(string input, ref int index, out int result)
        {
            var number = 0;
            var digitNum = 0;
            var isMinus = false;
            if (input[index] == '-')
            {
                index++;
                isMinus = true;
            }
            while (index < input.Length && Char.IsDigit(input[index]))
            {
                number = number * 10 + (int)Char.GetNumericValue(input[index]);
                digitNum++;
                if (digitNum == 2 && number == 0)
                {
                    result = number;
                    return false;
                }
                index++;
            }

            result = number * (isMinus ? -1 : 1);
            return true;
        }
    }
}
