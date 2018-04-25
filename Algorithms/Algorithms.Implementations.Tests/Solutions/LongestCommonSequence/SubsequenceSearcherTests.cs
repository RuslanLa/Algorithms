using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.LongestCommonSubsequence;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.LongestCommonSequence
{
    public class SubsequenceSearcherTests
    {
        private readonly SubsequenceSearcher _subsequenceSearcher = new SubsequenceSearcher();

        [Theory]
        [InlineData(";RBEDE>NG1>96O9G?690?33;B7<G?66?1BN4BIG0:@B93@IPL@1G<:48O62<", "8K?ANR8H154JB9JRDM82A@NR5B3J=F8;F:KC10>481OG;:42D5G2R0OLP@<;", "RBDN1>OG;4G0P@<")]
        [InlineData("nothardlythefinaltest", "zzzfinallyzzz", "final")]
        public void Search(string a, string b, string expected)
        {
            _subsequenceSearcher.Find(a, b).ShouldBe(expected);
        }
    }
}
