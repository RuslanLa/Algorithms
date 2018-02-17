using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.RgbToHex;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.RgbToHex
{
    public class ByteExtensionsTests
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(9, "9")]
        [InlineData(15, "F")]
        [InlineData(255, "FF")]
        [InlineData(128, "80")]
        public void ByteToHexTest(byte value, string expected)
        {
            var hex = value.ToHex();
            hex.ShouldBe(expected);
        }
    }
}
