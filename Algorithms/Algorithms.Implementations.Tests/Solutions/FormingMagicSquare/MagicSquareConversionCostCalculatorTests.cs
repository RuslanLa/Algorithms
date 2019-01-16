using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.FormingMagicSquare;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.FormingMagicSquare
{
    public class MagicSquareConversionCostCalculatorTests
    {
        private MagicSquareConversionCostCalculator _calculator = new MagicSquareConversionCostCalculator();


        [Theory]
        [InlineData(new int[]{4, 9, 2, 3, 5, 7, 8, 1, 5}, 1)]
        public void Calculate(int[] square, int expectedCost)
        {
            var cost = _calculator.Calculate(ConvertToMatrix(square));
            cost.ShouldBe(expectedCost);
        }

        private int[][] ConvertToMatrix(int[] square)
        {
            var result = new int[3][];
            for (int i = 0; i < square.Length; i++)
            {
                var row = i / 3;
                var column = i % 3;
                if (column == 0)
                {
                    result[row] = new int[3];
                }

                result[row][column] = square[i];
            }

            return result;
        }
    }
}
