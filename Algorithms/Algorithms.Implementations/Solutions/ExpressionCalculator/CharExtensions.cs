using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.ExpressionCalculator
{
    public static class CharExtensions
    {
        public static bool IsDivision(this char input) => input == '/';
        public static bool IsMultiplication(this char input) => input == '*';
        public static bool IsSum(this char input) => input == '+';
        public static bool IsMinus(this char input) => input == '-';
        public static bool IsOpeningBracket(this char input) => input == '(';
        public static bool IsClosingBracket(this char input) => input == ')';
        public static double ToNumber(this CharEnumerator enumerator, out bool hasNext)
        {
            var number = 0;
            hasNext = true;
            while (hasNext && Char.IsDigit(enumerator.Current))
            {
                number = number * 10 + (int)Char.GetNumericValue(enumerator.Current);
                hasNext = enumerator.MoveNext();
            }

            if (!hasNext||enumerator.Current != '.')
            {
                return number;
            }

            var rank = 1;
            double decimalPart = 0;
            hasNext = enumerator.MoveNext();
            while (hasNext && Char.IsDigit(enumerator.Current))
            {
                decimalPart = decimalPart * 10 + (int)Char.GetNumericValue(enumerator.Current);
                rank *= 10;
                hasNext = enumerator.MoveNext();

            }
            return number + (decimalPart/rank); 
        }
    }
}
