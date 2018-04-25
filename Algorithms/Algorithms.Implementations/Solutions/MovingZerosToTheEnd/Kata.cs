using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The solution for the kata https://www.codewars.com/kata/moving-zeros-to-the-end
/// </summary>
public class Kata
{
    public static int[] MoveZeroes(int[] arr)
    {
        return arr.Where(x => x != 0).Concat(Enumerable.Repeat(0, arr.Length)).Take(arr.Length).ToArray();
    }
}