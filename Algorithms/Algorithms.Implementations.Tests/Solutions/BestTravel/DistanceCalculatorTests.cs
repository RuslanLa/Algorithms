using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.BestTravel;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.BestTravel
{
    public class DistanceCalculatorTests
    {
        private readonly DistanceCalculator _distanceCalculator = new DistanceCalculator();

        [Theory]
        [InlineData(163, 3, new[] {50, 55, 56, 57, 58}, 163)]
        [InlineData(163, 3, new[] {50}, null)]
        [InlineData(230, 3, new[] { 91, 74, 73, 85, 73, 81, 87 }, 228)]
        [InlineData(331, 4, new[] { 91, 74, 73, 85, 73, 81, 87 }, 331)]
        [InlineData(230, 4, new[] { 100, 76, 56, 44, 89, 73, 68, 56, 64, 123, 2333, 144, 50, 132, 123, 34, 89 }, 230)]
        [InlineData(430, 5, new[] { 100, 76, 56, 44, 89, 73, 68, 56, 64, 123, 2333, 144, 50, 132, 123, 34, 89 }, 430)]
        public void GetBestDistance(int maxDistance, int townsCount, int[] towns, int? expected)
        {
            _distanceCalculator.GetBestDistance(maxDistance, townsCount, new List<int>(towns))
                .ShouldBe(expected);
        }
    }
}
