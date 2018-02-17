
//using System;
//using System.Collections.Generic;
//using System.Linq;

///// <summary>
///// #50KataChallenge
///// Solution for the https://www.codewars.com/kata/highest-scoring-word/train/csharp
///// </summary>
//public class Kata
//{
//    public static string High(string s)
//    {
//        var words = s.Split(' ').Select(w => new {Word = w, Value = EvaluateWord(w)}).ToList();
//        var max = words.Max(w => w.Value);
//        return words.Where(w => w.Value == max).Select(w => w.Word).FirstOrDefault();
//    }

//    private static int _alphabetBegin = Convert.ToInt32('a') - 1;

//    private static int EvaluateWord(string word) => GetCharactersEnumeration(word).Sum();

//    private static IEnumerable<int> GetCharactersEnumeration(string word)
//    {
//        foreach (var character in word)
//        {
//            yield return (byte)(character - _alphabetBegin);
//        }
//    }

//}