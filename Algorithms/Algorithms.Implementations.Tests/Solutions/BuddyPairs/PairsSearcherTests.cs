using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.BuddyPairs;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.BuddyPairs
{
    public class PairsSearcherTests
    {
        [Theory]
        [InlineData(10, 50, "(48 75)")]
        [InlineData(1071625, 1103735, "(1081184 1331967)")]
        public void GetDivisors(long start, long limit, string result)
        {
            new PairsSearcher().Find(start, limit).ShouldBe(result);
        }
    }
}
