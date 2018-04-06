using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.FactorialTail;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.FactorialTail
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(10, 10, 2)]
        [InlineData(16, 16, 3)]
        [InlineData(2, 524288, 524287)]
        [InlineData(12, 26, 10)]
        [InlineData(12, 27, 11)]
        public void CalculateZerosTest(int basis, int number, int expected)
        {
            new Calculator().CalculateZeros(basis, number).ShouldBe(expected);
        }
    }
}
