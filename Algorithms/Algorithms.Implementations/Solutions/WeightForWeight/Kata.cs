using System;
using System.Linq;

/// <summary>
/// Solution for the KATA https://www.codewars.com/kata/55c6126177c9441a570000cc
/// </summary>
public class WeightSort
{
    public static string orderWeight(string input)
    {
        return String.Join(" ", input.Split(' ').Select(x => x.Trim()).Select(x => new
        {
            num = x,
            sum = CalculateDigitsSum(x)
        }).OrderBy(x => x.sum).ThenBy(x => x.num).Select(x => x.num));
    }

    private static int CalculateDigitsSum(string number)
    {
        var sum = 0;
        foreach (var digit in number.Select(x => (int)Char.GetNumericValue(x)))
        {
            sum += digit;
        }

        return sum;
    }

}