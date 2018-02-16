using Algorithms.Implementations.Solutions;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions
{
    public class SortSwapCountCalculatorTest
    {
        public SortSwapCountCalculatorTest()
        {
            _counter = new SortSwapsCountCalculator();
        }
        private readonly SortSwapsCountCalculator _counter;

        [Theory]
        [InlineData(new int[] { 4, 3, 2, 1 }, 2)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 0)]
        [InlineData(new int[] { 2, 4, 5, 1, 3 }, 3)]
        [InlineData(new int[] { 8, 8, 1 }, 1)]
        [InlineData(new int[] { 54, 43, 32, 11 }, 2)]
        public void TestCount(int[] input, int expected)
        {
            var result = _counter.Calculate(input);
            result.ShouldBe(expected);
        }
    }
}
