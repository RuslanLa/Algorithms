using Algorithms.Implementations.Solutions.StringsMix;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.StringsMix
{
    public class MixerTests
    {
        private readonly Mixer _mixer = new Mixer();
        [Theory]
        [InlineData(" In many languages", " there's a pair of functions", "1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt")]
        public void Mix(string first, string second, string expected)
        {
            _mixer.Mix(first, second).ShouldBe(expected);
        }
    }
}
