using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.FactorialDecomposition;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.FactorialDecomposition
{
    public class DecomposerTests
    {
        [Theory]
        [InlineData(22, "2^19 * 3^9 * 5^4 * 7^3 * 11^2 * 13 * 17 * 19")]
        public void Decompose(int n, string expected)
        {
            new Decomposer().Decompose(n).ShouldBe(expected);
        }
    }
}
