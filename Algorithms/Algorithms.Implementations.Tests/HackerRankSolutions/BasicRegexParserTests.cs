using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Hackerrank.Solutions.Implementations;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.HackerRankSolutions
{
    public class BasicRegexParserTests
    {
        private BasicRegexParser _parser { get; set; }

        public BasicRegexParserTests()
        {
            _parser = new BasicRegexParser();
        }

        [Theory]
        [InlineData("abaa", "a.*a*", true)]
        [InlineData("bbbbbbbb", ".*.*.*.*a", false)]
        [InlineData("", "", true)]
        [InlineData("aa", "a", false)]
        [InlineData("", "a*", true)]
        [InlineData("abbdbb", "ab*d", false)]
        [InlineData("aba", "a.a", true)]
        [InlineData("acd", "ab*c.", true)]
        [InlineData("abaa", "a.*a*", true)]
        public void TestParse(string text, string pattern, bool expectedResult)
        {
            var actualResult = _parser.IsMatch(text, pattern);
            actualResult.ShouldBe(expectedResult);
        }

    }
}
