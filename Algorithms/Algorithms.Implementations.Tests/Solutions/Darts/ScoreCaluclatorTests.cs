using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.Darts;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Darts
{
    public class ScoreCaluclatorTests
    {
        public ScoreCaluclatorTests()
        {
            _scoreCalculator = new ScoreCalculator();
        }
        private readonly ScoreCalculator _scoreCalculator;

        [Theory]
        [InlineData(-133.69, -147.38, "X")]
        [InlineData(-73.905, -95.94, "7")]
        public void GetScore(double x, double y, string expected)
        {
            _scoreCalculator.Calculate(x, y).ShouldBe(expected);
        }
    }
}
