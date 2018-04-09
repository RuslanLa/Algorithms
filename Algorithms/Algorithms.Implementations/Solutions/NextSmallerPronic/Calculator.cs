using System;


namespace Algorithms.Implementations.Solutions.NextSmallerPronic
{
    /// <summary>
    /// Solution for the Kata  https://www.codewars.com/kata/next-smaller-pronic
    /// </summary>
    public class Calculator
    {
        public ulong CalculateNextSmallerPronic(ulong x)
        {
            var n = (ulong) System.Math.Sqrt(x);
            Console.WriteLine(n);
            var first = n * (n - 1);
            var second = n * (n + 1);
            return second < x ? second : first;
        }
    }
}
