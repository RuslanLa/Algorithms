using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.ExpressionCalculator
{
    public class Evaluator
    {
        public double Evaluate(string expression)
        {
            return Evaluate(expression, expression.GetEnumerator());
        }

        public double Evaluate(string expression, CharEnumerator enumerator)
        {
            return GetSummands(expression, enumerator).Sum();
        }


        public IEnumerable<double> GetSummands(string expression, CharEnumerator enumerator)
        {
            double? currentNumber = null;
            bool isMinus = false;
            Func<double, double, double> currentFunc = null;
            bool nextGotten = false;
            while (nextGotten || enumerator.MoveNext())
            {
                nextGotten = false;
                if (enumerator.Current.IsMinus() || enumerator.Current.IsSum())
                {
                    var valueToReturn = currentNumber;
                    if (enumerator.Current.IsMinus())
                    {
                        isMinus = !isMinus;
                    }
                    if (valueToReturn.HasValue && currentFunc == null)
                    {
                        currentNumber = null;
                        yield return valueToReturn.Value;
                    }
                    continue;
                }

                if (enumerator.Current.IsClosingBracket())
                {
                    break;
                }

                if (Char.IsDigit(enumerator.Current) || enumerator.Current.IsOpeningBracket())
                {
                    var newNumber = (enumerator.Current.IsOpeningBracket()? Evaluate(expression, enumerator):
                        enumerator.ToNumber(out nextGotten)) * (isMinus?-1:1);
                    isMinus = false;
                    if (currentFunc != null && currentNumber.HasValue)
                    {
                        currentNumber = currentFunc(currentNumber.Value, newNumber);
                        currentFunc = null;
                        continue;
                    }
                    currentNumber = newNumber;
                    continue;
                }

                if (enumerator.Current.IsMultiplication() || enumerator.Current.IsDivision())
                {
                    currentFunc = enumerator.Current.IsMultiplication() ? (Func<double, double, double>)((firstArg, secondArg) => firstArg * secondArg) : ((firstArg, secondArg) => firstArg / secondArg);
                    continue;
                }

            }

            if(currentNumber != null)
            {
                yield return currentNumber.Value;
            }
        }
    }
}
