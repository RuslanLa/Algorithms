using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.UnknownDigit;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.UnknowDigit
{
    public class DigitCalculatorTest
    {
        [Theory]
        [InlineData("1+1=?", 2)]
        [InlineData("123*45?=5?088", 6)]
        [InlineData("123?45*?=?", 0)]
        [InlineData("123?45-?=123?45", 0)]
        [InlineData("??605*-63=-73???5",1)]
        public void Calculate(string expression, int result)
        {
            new DigitCalculator().Calculate(expression).ShouldBe(result);
        }
    }
}
