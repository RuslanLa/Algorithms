using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.IntRecreation;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.IntegersRecreationOne
{
    public class SumSquaredDivisorsTests
    {

        [Theory]
        [InlineData(1, 250, new long[]{1, 1, 42, 2500, 246, 84100})]
        public void TestCount(long min, long max, long[] expected)
        {
            var result = SumSquaredDivisors.CalculateListSquared(min, max).SelectMany(x=>x).ToArray();
            result.Length.ShouldBe(expected.Length);
            for (int i = 0; i < result.Length; i++)
            {
              result[i].ShouldBe(expected[i]);   
            }
        }
    }
}
