using Algorithms.Implementations.Solutions.ExpressionCalculator;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.ExpressionCalculator
{
    public class EvaluatorTest
    {
        private readonly Evaluator _evaluator;
        public EvaluatorTest()
        {
            _evaluator = new Evaluator();
        }

        [Theory]
        [InlineData("1+1/2", 1.5)]
        [InlineData("1+1/2/5", 1.1)]
        [InlineData("1+1/2/5-3*4/2", -4.9)]
        [InlineData("-11+1/2/5-3*4/2", -16.9)]
        [InlineData("-11-1*2+14-8+1/2/5-3*4/2", -12.9)]
        [InlineData("12* 123/(-5 + 2)", -492)]
        [InlineData("12.435 + 0.565", 13)]
        [InlineData("123.45*(678.90 / (-2.5+ 11.5)-(80 -19) *33.25) / 20 + 11", -12042.760875)]
        [InlineData("(1 - 2) + -(-(-(-4)))", 3)]
        [InlineData("(1 - 2) + -(-(-(-(-4))))", -5)]
        [InlineData("1 - -(-(-(-4)))", -3)]
        [InlineData("(123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) - (123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) + (13 - 2)/ -(-11)", 1)]
        [InlineData("12*-1", -12)]

        public void Evaluate(string expression, double expected)
        {
            _evaluator.Evaluate(expression).ShouldBe(expected);
        }

    }
}
