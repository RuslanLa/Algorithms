using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.BigPronic;
using Algorithms.Implementations.Solutions.HammingsCode;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.BigPronic
{
    public class PronicDetectorTest
    {
        public PronicDetectorTest()
        {
            _detector = new PronicDetector();
        }
        private readonly PronicDetector _detector;

        [Theory]
        [InlineData(1152921507828072449, false)]
        [InlineData(long.MinValue, false)]
        public void TestCount(long n, bool expected)
        {
            _detector.IsPronic(n).ShouldBe(expected);
        }
    }
}
