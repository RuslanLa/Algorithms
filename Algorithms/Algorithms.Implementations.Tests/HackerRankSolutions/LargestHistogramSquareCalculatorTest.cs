using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Solutions.Implementations;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.HackerRankSolutions
{
    public class LargestHistogramSquareCalculatorTest
    {
        public LargestHistogramSquareCalculatorTest()
        {
            _calculator = new LargestHistogramSquareCalculator();
        }
        private readonly LargestHistogramSquareCalculator _calculator;

        [Theory]
        [InlineData(new int[] { 1, 2, 2, 2, 3, 4, 1 }, 10)]
        [InlineData(new int[] { 1, 2, 2, 1, 3, 4, 1 }, 7)]
        [InlineData(new int[] { 1, 2, 2, 0, 3, 4, 1 }, 6)]
        public void TestCount(int[] input, int expected)
        {
            var result = _calculator.Calculate(input);
            result.ShouldBe(expected);
        }
    }
}
