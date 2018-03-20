using System;
using System.Collections.Generic;
using System.Linq;
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

        if (!hasNext || enumerator.Current != '.')
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
        return number + (decimalPart / rank);
    }
}
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
                var newNumber = (enumerator.Current.IsOpeningBracket() ? Evaluate(expression, enumerator) :
                    enumerator.ToNumber(out nextGotten)) * (isMinus ? -1 : 1);
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

        if (currentNumber != null)
        {
            yield return currentNumber.Value;
        }
    }
}