//using System.Collections.Generic;
//using System.Linq;
//using System;

//public class SumSquaredDivisors
//{
//    public static string listSquared(long m, long n)
//    {
//        var results = new List<string>();
//        for (var i = m; i <= n; i++)
//        {
//            var sum = CalculateSumOfSquaredDivisors(i);
//            if (Math.Sqrt(sum) % 1 != 0)
//            {
//                continue;
//            }

//            results.Add($"[{i}, {sum}]");
//        }
//        return $"[{String.Join(", ", results)}]";
//    }

//    private static long CalculateSumOfSquaredDivisors(long number)
//    {
//        return GetDivisors(number).Sum(n => n * n);
//    }

//    private static List<long> GetDivisors(long number)
//    {
//        var divisors = new List<long> { number };
//        for (var i = 1; i <= number / 2; i++)
//        {
//            if (number % i != 0)
//            {
//                continue;
//            }

//            divisors.Add(i);
//        }

//        return divisors;
//    }
//}