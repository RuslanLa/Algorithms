//using System.Collections.Generic;
//using System.Linq;

//public static class Kata
//{
//    public static int Solution(int value)
//    {
//        return SumMultiplesOf3And5(value);
//    }

//    private static int SumMultiplesOf3And5(int maxMultiple)
//    {
//        return GetMultiples(maxMultiple, 3).Concat(GetMultiples(maxMultiple, 5)).Distinct().Sum();
//    }

//    private static IEnumerable<int> GetMultiples(int maxMultiple, int multiplicator)
//    {
//        var curValue = multiplicator;
//        while (curValue < maxMultiple)
//        {
//            var prevValue = curValue;
//            curValue += multiplicator;
//            yield return prevValue;
//        }
//    }

//}