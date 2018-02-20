using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.Rot13;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Rot13
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("test", "grfg")]
        public void ToRot13(string message, string expected)
        {
            message.ToRot13().ShouldBe(expected);
        }
    }
}
