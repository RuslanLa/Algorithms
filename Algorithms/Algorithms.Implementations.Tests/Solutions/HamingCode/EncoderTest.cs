using Algorithms.Implementations.Solutions.HammingsCode;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.HamingCode
{
    public class EncoderTest
    {
        public EncoderTest()
        {
            _encoder = new Encoder();
        }
        private readonly Encoder _encoder;

        [Theory]
        [InlineData(new bool[]{true, false, false, true, true, false, true, false}, new bool[] {false, true, true, true, false, false, true, false, true, false, true, false})]
        public void TestCount(bool[] input, bool[] expected)
        {
            var result = _encoder.Encode(input);
            result.Length.ShouldBe(expected.Length);
            for(var i=0; i<expected.Length; i++)
            {
                result[i].ShouldBe(expected[i]);
            }
        }
    }
}
