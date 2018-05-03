using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.PackingABackpack;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.PackingABackpack
{
    public class PackerTests
    {
        private readonly Packer _packer = new Packer();

        [Theory]
        [InlineData(new int[] { 15, 10, 9, 5 }, new int[] { 1, 5, 3, 4 }, 8, 29)]
        public void GetMaxBagScore(int[] scores, int[] weights, int capacity, int expected)
        {
            _packer.GetMaxBagScore(scores, weights, capacity).ShouldBe(expected);
        }
    }
}
