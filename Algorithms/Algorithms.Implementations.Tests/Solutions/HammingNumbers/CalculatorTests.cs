using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.HammingNumbers;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.HammingNumbers
{
    public class CalculatorTests
    {
        private readonly Calculator _hammingNumberCalculator = new Calculator();
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(7, 8)]
        [InlineData(8, 9)]
        [InlineData(9, 10)]
        public void CalculateNth(int n, long expected)
        {
            _hammingNumberCalculator.CalculateNth(n).ShouldBe(expected);
        }
    }
}
