using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.ReadableDurationFormat;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.ReadableDurationFormat
{
    public class DurationConverterTests
    {
        [Theory]
        [InlineData(62, "1 minute and 2 seconds")]
        public void ToUserFriendlyFormat(int seconds, string expected)
        {
            DurationConverter.ToUserFriendlyFormat(seconds).ShouldBe(expected);
        }
    }
}
