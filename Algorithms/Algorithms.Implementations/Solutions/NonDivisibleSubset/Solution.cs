//using System.IO;
//using System;

//public class SubsetLengthCalculator
//{
//    public int Calculate(int[] set, int k)
//    {
//        var remainders = this.CalculateRemaindersCount(set, k);
//        return this.CalculateCountByRemainders(remainders, k);
//    }

//    private int CalculateCountByRemainders(int[] remainders, int k)
//    {
//        var count = this.CalculateCountForUsualCase(remainders, k);
//        count += this.CalculateCountForZeroRemainder(remainders, k);
//        count += this.CalculateCountForMiddleRemainder(remainders, k);
//        return count;
//    }

//    private int CalculateCountForUsualCase(int[] remainders, int k)
//    {
//        var count = 0;
//        for (var i = 1; i <= (k - 1) / 2; i++)
//        {
//            var max = remainders[i] > remainders[k - i] ? remainders[i] : remainders[k - i];
//            count += max;
//        }

//        return count;
//    }

//    private int CalculateCountForMiddleRemainder(int[] remainders, int k)
//    {
//        return k % 2 == 0 && remainders[k / 2] > 0 ? 1 : 0;
//    }

//    private int CalculateCountForZeroRemainder(int[] remainders, int k)
//    {
//        return remainders[0] > 0 ? 1 : 0;
//    }

//    private int[] CalculateRemaindersCount(int[] set, int k)
//    {
//        var remainders = new int[k];
//        foreach (var element in set)
//        {
//            remainders[element % k]++;
//        }
//        return remainders;
//    }
//}
//class Solution
//{
//    // Complete the nonDivisibleSubset function below.
//    static int nonDivisibleSubset(int k, int[] S)
//    {
//        return new SubsetLengthCalculator().Calculate(S, k);
//    }

//    static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
//        string[] nk = Console.ReadLine().Split(' ');
//        int n = Convert.ToInt32(nk[0]);
//        int k = Convert.ToInt32(nk[1]);
//        int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), STemp => Convert.ToInt32(STemp));
//        int result = nonDivisibleSubset(k, S);
//        textWriter.WriteLine(result);
//        textWriter.Flush();
//        textWriter.Close();
//    }
//}
