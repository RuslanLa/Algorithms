using Algorithms.Implementations.Solutions.Strings.Medium.SherlockAndAnagrams;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Strings.Medium
{
    public class AnagramsCounterTest
    {
        public AnagramsCounterTest()
        {
            _counter=new AnagramsCounter();
        }
        private readonly AnagramsCounter _counter; 

        [Theory]
        [InlineData("abba", 4)]
        [InlineData("abcd", 0)]
        [InlineData("", 0)]
        [InlineData("ifailuhkqq", 3)]
        [InlineData("hucpoltgty", 2)]
        [InlineData("ovarjsnrbf", 2)]
        [InlineData("pvmupwjjjf", 6)]
        [InlineData("aaa", 4)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650)]
        [InlineData("bbcaadacaacbdddcdbddaddabcccdaaadcadcbddadababdaaabcccdcdaacadcababbabbdbacabbdcbbbbbddacdbbcdddbaaa", 4832)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650)]
        [InlineData("cacccbbcaaccbaacbbbcaaaababcacbbababbaacabccccaaaacbcababcbaaaaaacbacbccabcabbaaacabccbabccabbabcbba", 13022)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650)]
        [InlineData("bbcbacaabacacaaacbbcaabccacbaaaabbcaaaaaaaccaccabcacabbbbabbbbacaaccbabbccccaacccccabcabaacaabbcbaca", 9644)]
        [InlineData("cbaacdbaadbabbdbbaabddbdabbbccbdaccdbbdacdcabdbacbcadbbbbacbdabddcaccbbacbcadcdcabaabdbaacdccbbabbbc", 6346)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650)]
        [InlineData("babacaccaaabaaaaaaaccaaaccaaccabcbbbabccbbabababccaabcccacccaaabaccbccccbaacbcaacbcaaaaaaabacbcbbbcc", 8640)]
        [InlineData("bcbabbaccacbacaacbbaccbcbccbaaaabbbcaccaacaccbabcbabccacbaabbaaaabbbcbbbbbaababacacbcaabbcbcbcabbaba", 11577)]
        public void TestCount(string input, int expected)
        {
            var result = _counter.Count(input);
            result.ShouldBe(expected);
        }
    }
}
