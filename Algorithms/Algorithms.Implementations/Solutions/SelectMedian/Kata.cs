//using System;
//using System.Linq;

//public interface IWarrior
//{
//    // a.IsBetter(b) returns true if and only if
//    // warrior a is no worse than warrior b, i.e. a>=b
//    bool IsBetter(IWarrior other);
//}

//public static class Kata
//{
//    // warriors is IWarrior[5]
//    public static IWarrior SelectMedian(IWarrior[] warriors)
//    {
//        if (warriors.Length != 5)
//        {
//            throw new InvalidOperationException("Unexpected warriors count");
//        }
//        var firstResult = warriors[0].IsBetter(warriors[1]);
//        var secondResult = warriors[2].IsBetter(warriors[3]);

//        var firstWinner = firstResult ? warriors[0] : warriors[1];
//        var secondWinner = secondResult ? warriors[2] : warriors[3];
//        var firstLoser = firstResult ? warriors[1] : warriors[0];
//        var secondLoser = secondResult ? warriors[3] : warriors[2];

//        var thirdResult = firstLoser.IsBetter(secondLoser);
//        var b = thirdResult ? secondWinner : firstWinner;
//        var d = thirdResult ? firstLoser : secondLoser;
//        var e = thirdResult ? firstWinner : secondWinner;
//        var c = warriors[4];

//        if (c.IsBetter(b))
//        {
//            if (d.IsBetter(b))
//            {
//                return c.IsBetter(d) ? d : c;
//            }
//            return e.IsBetter(b) ? b : e;
//        }

//        if (d.IsBetter(c))
//        {
//            return b.IsBetter(d) ? d : b;
//        }

//        return e.IsBetter(c) ? c : e;
//    }
//}

