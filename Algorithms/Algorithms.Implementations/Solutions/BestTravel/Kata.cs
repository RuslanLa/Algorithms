using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for the KATA
/// https://www.codewars.com/kata/55e7280b40e1c4a06d0000aa
/// </summary>
public static class SumOfK
{
    public static int? chooseBestSum(int t, int k, List<int> ls)
    {
        Console.WriteLine("t:"+t);
        Console.WriteLine("k:"+k);
        Console.WriteLine("ls:"+String.Join(", ", ls));
        return GetBestDistance(t, k, ls);
    }
    private static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
            elements.SelectMany((e, i) => Combinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
    }
    public static int? GetBestDistance(int maxDistance, int townsCount, List<int> distances)
    {
        return Combinations(distances, townsCount).Select(c => c.Sum()).Where(s => s <= maxDistance)
            .OrderByDescending(s => s).Select(d => (int?)d).FirstOrDefault();
    }
}