using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.SquareDecomposition;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.SquareDecomposition
{
    public class DecomposerTests
    {
        private readonly Decomposer _decomposer = new Decomposer();

        [Theory]
        [InlineData(11, "1 2 4 10")]
        [InlineData(12, "1 2 3 7 9")]
        public void Decompose(long n, string expected)
        {
            _decomposer.Decompose(n).ShouldBe(expected);
        }
    }
}
