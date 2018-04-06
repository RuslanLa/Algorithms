using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for Kata https://www.codewars.com/kata/factorial-tail
/// Structure was inherited from Kata solution
/// </summary>
public class FactorialTail
{
    public static int zeroes(int basis, int number)
    {
        var biggestFactor = FactorizeBasis(basis).GroupBy(f => f)
            .Select(g => new Factor()
            {
                Count = g.Count(),
                Number = g.Key
            }).ToArray();
        return CalculateEntries(number, biggestFactor);
    }

    private class Factor
    {
        public int Number { get; set; }
        public int Count { get; set; }
    }

    private static IEnumerable<int> FactorizeBasis(int basis)
    {
        var factor = 2;

        while (basis > 1)
        {
            while (basis % factor == 0)
            {
                basis = basis / factor;
                yield return factor;

            }

            factor++;
        }
    }

    private static int CalculateEntries(int number, Factor[] factors)
    {
        var entries = Int32.MaxValue;
        foreach (var currentFactor in factors)
        {
            var count = 0;
            var factor = number / currentFactor.Number;
            while (factor > 0)
            {
                count += factor;
                factor = factor / currentFactor.Number;
            }

            entries = Math.Min(count / currentFactor.Count, entries);
        }

        return entries;
    }
}