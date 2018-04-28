using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.StringsMix
{
    /// <summary>
    /// Solution for the Kata 
    /// https://www.codewars.com/kata/5629db57620258aa9d000014
    /// </summary>
    public class Mixer
    {
        private enum OccurenceType
        {
            First,
            Second,
            Both
        }
        private class Occurrence
        {
            public Occurrence(int firstCount, int secondCount, char letter)
            {
                Letter = letter;
                Count = firstCount > secondCount ? firstCount : secondCount;
                Type = Count == firstCount && Count == secondCount
                    ? OccurenceType.Both
                    : (Count == firstCount ? OccurenceType.First : OccurenceType.Second);
            }
            public int TypeOrder
            {
                get
                {
                    switch (Type)
                    {
                        case OccurenceType.Both:
                            return 3;
                        case OccurenceType.First:
                            return 1;
                        case OccurenceType.Second:
                            return 2;
                        default:
                            return 3;
                    }
                }
            }
            private OccurenceType Type { get;}
            public int Count { get; }
            public char Letter { get; }

            public override string ToString()
            {
                var prefix = "=";
                if (Type == OccurenceType.First)
                {
                    prefix = "1";
                }
                if (Type == OccurenceType.Second)
                {
                    prefix = "2";
                }

                return $"{prefix}:{String.Join("", Enumerable.Repeat(Letter, Count))}";
            }
        }
        public string Mix(string first, string second)
        {
            var firstDict = CountLetters(first);
            var secondDict = CountLetters(second);
            return String.Join("/", MixOccurencies(firstDict, secondDict));
        }

        private Dictionary<char, int> CountLetters(string input)
        {
            return input.Where(i => Char.IsLower(i) && Char.IsLetter(i)).GroupBy(l => l)
                .ToDictionary(g => g.Key, g => g.Count());
        }


        private IEnumerable<Occurrence> MixOccurencies(Dictionary<char, int> first, Dictionary<char, int> second)
        {
            return first.Select(v=>new
            {
                v,
                isFirst = true
                
            }).Concat(second.Select(v => new
            {
                v,
                isFirst = false
            })).GroupBy(x=>x.v.Key).Select(g=>
                new Occurrence(g.Where(x=>x.isFirst).Select(x=>x.v.Value).FirstOrDefault(),
                    g.Where(x => !x.isFirst).Select(x => x.v.Value).FirstOrDefault(),
                    g.Key)).Where(o => o.Count > 1)
                .OrderByDescending(o => o.Count).ThenBy(o => o.TypeOrder).ThenBy(o => o.Letter);
        }
    }
}

