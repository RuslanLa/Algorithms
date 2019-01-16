using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.FormingMagicSquare
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/magic-square-forming/problem
    /// </summary>
    public class MagicSquareConversionCostCalculator
    {
        private static int[][] MagicSquares = new[]
        {
            new[] {8, 1, 6, 3, 5, 7, 4, 9, 2},
            new[] {6, 1, 8, 7, 5, 3, 2, 9, 4},
            new[] {4, 9, 2, 3, 5, 7, 8, 1, 6},
            new[] {2, 9, 4, 7, 5, 3, 6, 1, 8},
            new[] {8, 3, 4, 1, 5, 9, 6, 7, 2},
            new[] {4, 3, 8, 9, 5, 1, 2, 7, 6},
            new[] {6, 7, 2, 1, 5, 9, 8, 3, 4},
            new[] {2, 7, 6, 9, 5, 1, 4, 3, 8}
        };

        public int Calculate(int[][] square)
        {
            var cost = Int32.MaxValue;
            for (var i = 0; i < 8; i++)
            {
                var magic = MagicSquares[i];
                var currentCost = 0;
                for (var j = 0; j < 9; j++)
                {
                    var magicValue = magic[j];
                    var squareValue = square[j / 3][j % 3];
                    var diff = magicValue - squareValue;
                    diff = diff < 0 ? -diff : diff;
                    currentCost += diff;
                }

                if (currentCost < cost)
                {
                    cost = currentCost;
                }
            }

            return cost;
        }
    }
}
