using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.MiddlePermutation;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.MiddlePermutation
{
    public class PermutationBuilderTests
    {
        private readonly PermutationBuilder _permutationBuilder = new PermutationBuilder();

        [Theory]
        [InlineData("abc", "bac")]
        [InlineData("he", "eh")]
        [InlineData("abcd", "bdca")]
        [InlineData("abcdx", "cbxda")]
        [InlineData("abcdxg", "cxgdba")]
        [InlineData("abcdxgz", "dczxgba")]
        [InlineData("bcdgiklnopqrtuvxz", "onzxvutrqplkigdcb")]
        [InlineData("abcdeghijklmnopqrsuvwyz", "mlzywvusrqponkjihgedcba")]
        public void BuildPermutations(string input, string expected)
        {
            _permutationBuilder.BuildMiddle(input).ShouldBe(expected);
        }
    }
}
