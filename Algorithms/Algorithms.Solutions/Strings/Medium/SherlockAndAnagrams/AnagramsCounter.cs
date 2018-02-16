using System.Collections.Generic;

namespace Algorithms.Solutions.Strings.Medium.SherlockAndAnagrams
{
    /// <summary>
    /// Solution for the https://www.hackerrank.com/challenges/sherlock-and-anagrams/
    /// </summary>
    public class AnagramsCounter
    {
        public int Count(string input)
        {
            var occurencies=new Dictionary<string, int>();
            var anagramsCount = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var curWord =new OrderedWord();
                for (var j = i; j < input.Length; j++)
                {
                    var word = curWord.AddLetter(input[j]);
                    if (occurencies.ContainsKey(word))
                    {
                        occurencies[word]++;
                        anagramsCount += occurencies[word] - 1;
                        continue;
                    }
                    occurencies[word] = 1;
                }
            }

            return anagramsCount;
        }
    }
}
