using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.BaseConversion;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.BaseConversion
{
    public class ConverterTests
    {
        private readonly Converter _converter = new Converter();

        [Theory]
        [InlineData("15", Alphabet.DECIMAL, Alphabet.BINARY, "1111")]
        [InlineData("15", Alphabet.DECIMAL, Alphabet.OCTAL, "17")]
        [InlineData("1010", Alphabet.BINARY, Alphabet.DECIMAL, "10")]
        [InlineData("1010", Alphabet.BINARY, Alphabet.HEXA_DECIMAL, "a")]
        [InlineData("0", Alphabet.DECIMAL, Alphabet.ALPHA, "a")]
        public void Convert(string input, string source, string target, string expected)
        {
            _converter.Convert(input, source, target).ShouldBe(expected);
        }
    }
}
