using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.InfiniteSequenceOfNumbers;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.InfiniteSequenceOfNumbers
{
    public class PositionFinderTests
    {
        private readonly PositionFinder _positionFinder = new PositionFinder();

        [Theory]
        [InlineData("456", 3)]
        [InlineData("454", 79)]
        [InlineData("545556", 97)]
        [InlineData("455", 98)]
        [InlineData("9899100", 185)]
        [InlineData("00101", 190)]
        [InlineData("001", 190)]
        [InlineData("00", 190)]
        [InlineData("1234567891", 0)]
        [InlineData("10", 9)]
        [InlineData("53635", 13034)] //3536 3537
        [InlineData("040", 1091)] //400 401
        public void FindPosition(string sequence, long expected)
        {
            _positionFinder.Find(sequence).ShouldBe(expected);
        }
    }
}
