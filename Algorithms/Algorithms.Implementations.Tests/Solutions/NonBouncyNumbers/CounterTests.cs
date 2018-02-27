using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.NonBouncyNumbers;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.NonBouncyNumbers
{
    public class CounterTests
    {
        private readonly Counter _counter;
        public CounterTests()
        {
            _counter = new Counter();
        }

        [Theory]
        [InlineData(3, 475)]
        public void Test(int x, int expectedResult)
        {
            _counter.CalculateTotal(x).ShouldBe((BigInteger)expectedResult);
        }
    }
}
