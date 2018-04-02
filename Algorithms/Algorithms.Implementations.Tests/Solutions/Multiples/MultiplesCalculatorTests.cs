using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.Multiples;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Multiples
{
    public class MultiplesCalculatorTests
    {
        private MultiplesCalculator _calculator = new MultiplesCalculator();


        [Theory]
        [InlineData(10, 23)]
        public void Calculate(int value, int expected)
        {
            _calculator.SumMultiplesOf3And5(value).ShouldBe(expected);
        }
    }
}
