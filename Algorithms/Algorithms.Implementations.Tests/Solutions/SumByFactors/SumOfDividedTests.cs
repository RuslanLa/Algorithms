using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.SumByFactors;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.SumByFactors
{
    public class SumOfDividedTests
    {
        [Theory]
        [InlineData(new int[]{12, 15}, "(2 12)(3 27)(5 15)")]
        public void Test(int[] input, string expected)
        {
            SumOfDivided.sumOfDivided(input).ShouldBe(expected);
        }
    }
}
