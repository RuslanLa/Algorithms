using Algorithms.Hackerrank.Solutions.HammingsCode;
using Algorithms.Solutions.HammingsCode;
using Shouldly;
using Xunit;


namespace Algorithms.Implementations.Tests.HamingCode
{
    public class CheckerTest
    {
        public CheckerTest()
        {
            _checker = new Checker();
        }
        private readonly Checker _checker;

        [Theory]
        [InlineData(new bool[] { false, true, true, true, false, false, true, false, true, false, true, false }, null)]
        [InlineData(new bool[] { false, true, true, true, false, false, true, false, true, false, true, true }, 11)]
        public void TestCount(bool[] input, int? errorNum)
        {
            var result = _checker.Check(input);
            if(!errorNum.HasValue)
            result.ShouldBeNull();
            else
            result.ShouldBe(errorNum);
        }
    }
}
