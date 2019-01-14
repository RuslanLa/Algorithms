using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    public class DenseRankCalculator
    {
        public int[] Calculate(int[] leaderboardScores, int[] myScores)
        {
            var ranks = BuildRanks(leaderboardScores);
            var scores = new int[myScores.Length];
            var myScoreIndex = 0;

            for (var i = leaderboardScores.Length - 1; i >= 0; i--)
            {
                while (myScoreIndex < myScores.Length && leaderboardScores[i] > myScores[myScoreIndex])
                {
                    scores[myScoreIndex] = ranks[i] + 1;
                    myScoreIndex++;
                }

                while (myScoreIndex < myScores.Length && leaderboardScores[i] == myScores[myScoreIndex])
                {
                    scores[myScoreIndex] = ranks[i];
                    myScoreIndex++;
                }
            }

            if (myScoreIndex < myScores.Length)
            {
                for (var i = myScoreIndex; i < myScores.Length; i++)
                {
                    scores[i] = 1;
                }
            }

            return scores;
        }

        private int[] BuildRanks(int[] leaderboards)
        {
            var prevRank = 1;
            var ranks = new int[leaderboards.Length];
            var prev = -1;
            for (int i = 0; i < leaderboards.Length; i++)
            {
                if (leaderboards[i] < prev)
                {
                    prevRank++;
                }

                ranks[i] = prevRank;
                prev = leaderboards[i];
            }

            return ranks;
        }
    }
    // Complete the climbingLeaderboard function below.
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        return new DenseRankCalculator().Calculate(scores, alice);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int scoresCount = Convert.ToInt32(Console.ReadLine());
        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
        int aliceCount = Convert.ToInt32(Console.ReadLine());
        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
        int[] result = climbingLeaderboard(scores, alice);
        textWriter.WriteLine(string.Join("\n", result));
        textWriter.Flush();
        textWriter.Close();
    }
}
