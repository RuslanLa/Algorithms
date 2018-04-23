using System.Collections.Generic;
using System.Linq;

public class Johnann
{
    public static List<long> John(long n)
    {
        var ann = new long[n];
        var john = new long[n];
        FillBoth(ann, john);
        return new List<long>(john);
    }

    private static void FillNth(long[] currentPerson, long[] another, int n) => currentPerson[n] = n - another[currentPerson[n - 1]];

    private static void FillBoth(long[] ann, long[] john)
    {
        ann[0] = 1;
        john[0] = 0;

        for (var i = 1; i < ann.Length; i++)
        {
            FillNth(john, ann, i);
            FillNth(ann, john, i);
        }
    }

    public static List<long> Ann(long n)
    {
        var ann = new long[n];
        var john = new long[n];
        FillBoth(ann, john);
        return new List<long>(ann);
    }

    public static long SumJohn(long n)
    {
        return John(n).Sum();
    }

    public static long SumAnn(long n)
    {
        return Ann(n).Sum();
    }
}
