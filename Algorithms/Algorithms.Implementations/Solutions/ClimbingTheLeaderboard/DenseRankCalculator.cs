using System;
using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions.ClimbingTheLeaderboard
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/climbing-the-leaderboard
    /// </summary>
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
}

