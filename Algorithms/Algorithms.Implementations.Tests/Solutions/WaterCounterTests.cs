using Algorithms.Implementations.Solutions.SwimmingPool;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions
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
