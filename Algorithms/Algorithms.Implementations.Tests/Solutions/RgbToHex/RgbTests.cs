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
    public class RgbTests
    {
        [Theory]
        [InlineData(255, 255, 255, "FFFFFF")]
        [InlineData(255, 255, 300, "FFFFFF")]
        [InlineData(0, 0, 0, "000000")]
        [InlineData(148, 0, 211, "9400D3")]
        [InlineData(148, -20, 211, "9400D3")]
        public void ToHex(int r, int g, int b, string expected)
        {
            var rgb = new Rgb(r, g, b);
            rgb.ToHex().ShouldBe(expected);
        }
    }
}
