using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Algorithms.Solutions.Implementations.Easy.SwimmingPool;

namespace Algorithms.Implementations.Tests.HackerRankSolutions
{
    public class WaterCounterTests
    {
        public WaterCounterTests()
        {
            _counter = new WaterCounter();
        }
        private readonly WaterCounter _counter;

        [Theory]
        [InlineData(new int[] { 0, 1, 3, 2, 4 }, 1)]
        [InlineData(new int[] { 0, 1, 3}, 0)]
        [InlineData(new int[] { 5, 2, 3, 4 }, 3)]
        [InlineData(new int[] { 0, 1, 3, 2, 4, 5, 2, 1, 2 }, 2)]
        public void TestCount(int[] input, int expected)
        {
            var result = _counter.Count(input);
            result.ShouldBe(expected);
        }
    }
}
