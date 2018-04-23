using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.JohnAndAnnSignupCodewars;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.JohnAndAnnSignupCodewars
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new Calculator();

        [Theory]
        [InlineData(11, new long[] {0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6})]
        public void JohnTest(long n, long[] expected)
        {
            _calculator.John(n).ShouldBe(expected);
        }
    }
}
