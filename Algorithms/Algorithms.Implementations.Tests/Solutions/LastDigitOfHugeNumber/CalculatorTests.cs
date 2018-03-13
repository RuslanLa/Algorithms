using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.LastDigitOfHugeNumber;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.LastDigitOfHugeNumber
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        //[InlineData(new []{ 0 }, 1)]
        //[InlineData(new[] { 0, 0 }, 1)]
        //[InlineData(new[] { 0, 0, 0 }, 0)]
        //[InlineData(new[] { 1, 2 }, 1)]
        //[InlineData(new[] { 12, 30, 21 }, 6)]
        //[InlineData(new [] { 123232, 694022, 140249 }, 6)]
        //[InlineData(new []{ 499942, 898102, 846073 }, 6)]
        //[InlineData(new int[]{16}, 6)]
        [InlineData(new int[] { 2, 2, 2, 0 }, 4)]
        public void GetLastDigitTest(int[] array, int expected)
        {
            _calculator.GetLastDigit(array).ShouldBe(expected);
        }


        [Fact]
        public void RandomCase()
        {
            Random rnd = new Random();
            int rand1 = rnd.Next(0, 100);
            int rand2 = rnd.Next(0, 10);
            _calculator.GetLastDigit(new []{rand1, rand2}).ShouldBe((int)Math.Pow(rand1 % 10, rand2) % 10);
        }
    }
}
