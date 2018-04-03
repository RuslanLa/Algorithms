using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.MagnetParticulesInBoxes;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.MagnetParticulesInBoxes
{
    public class MagnetsTests
    {
        private Magnets _magnets = new Magnets();
        [Theory]
        [InlineData(1, 10, 0.5580321939764581)]
        [InlineData(10, 1000, 0.6921486500921933)]
        public void DoubleTest(int maxk, int maxn, double expectedResult)
        {
            _magnets.Doubles(maxk, maxn).ShouldBe(expectedResult);
        }
    }
}
