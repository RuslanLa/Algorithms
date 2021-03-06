﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.LongestCommonSubsequence
{
    public class SubsequenceSearcher
    {
        private class SubsequenceData
        {
            public int EndsOn { get; set; }
            public char[] Sequence { get; set; }
        }

        private Dictionary<char, int[]> DemountString(string input)
        {
            return input.Select((v, i)=> new {v, i}).GroupBy(x=>x.v).
                ToDictionary(g=>g.Key, g=>g.Select(x=>x.i).ToArray());
        }
        public string Find(string a, string b)
        {
            var sequences = new List<SubsequenceData>();
            var biggestLength = 0;
            char[] biggestSequence = null;
            var characters = DemountString(b);
            foreach (var character in a.ToCharArray())
            {
                if (!characters.ContainsKey(character))
                {
                    continue;
                }

                var sequencesCopy = sequences.ToArray();
                foreach (var position in characters[character])
                {
                    var prevInfo = FindPreviousSubsequence(position, sequencesCopy) ?? new SubsequenceData() { Sequence = new char[0] };
                    var newSequence = prevInfo.Sequence.Concat(new[] { character }).ToArray();
                    if (newSequence.Length > biggestLength)
                    {
                        biggestLength = newSequence.Length;
                        biggestSequence = newSequence;
                    }
                    sequences.Add(new SubsequenceData()
                    {
                        EndsOn = position,
                        Sequence = newSequence
                    });
                }
            }

            if (biggestLength == 0)
            {
                return String.Empty;
            }
            return new string(biggestSequence);
        }

        private SubsequenceData FindPreviousSubsequence(int index, SubsequenceData[] subsequences) =>
            subsequences.Where(s => s.EndsOn < index).OrderByDescending(s => s.Sequence.Length).FirstOrDefault();
    }
}
