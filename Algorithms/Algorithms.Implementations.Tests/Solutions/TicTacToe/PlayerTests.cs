using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.TicTacToe;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.TicTacToe
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(new int[]
        {
            2, 2, 0, 1, 0, 0, 0, 0, 0
        }, 1, new[] { 0, 2 })]
        [InlineData(new int[]
        {
            2, 2, 1, 2, 1, 0, 0, 0, 0
        }, 1, new[] { 2, 0 })]
        [InlineData(new int[]
        {
            2, 2, 0, 0, 0, 0, 1, 0, 0
        }, 1, new[] { 0, 2 })]
        [InlineData(new int[]
        {
            2, 2, 1, 1, 2, 2, 0, 1, 0
        }, 1, new[] { 2, 2 })]
        public void GetNextStep(int[] board, int currentNum, int[] expectedResult)
        {
            var converted = GetBoard(board);
            var step = new Player().GetNextStep(converted, currentNum);
            step.ShouldBe(expectedResult);
        }


        private int[][] GetBoard(int[] input) => input.Select((v, i) => new
        {
            i,
            v
        }).GroupBy(b => b.i / 3).OrderBy(g => g.Key).Select(g => g.Select(x => x.v).ToArray()).ToArray();

        [Theory]
        [InlineData(new int[]
        {
            2, 0, 1, 0, 1, 0, 0, 0, 0
        }, 1)]
        [InlineData(new int[]
        {
            2, 2, 1, 0, 1, 0, 0, 0, 0
        }, 1)]
        public void AssertCellIsEmpty(int[] board, int currentNum)
        {
            var converted = GetBoard(board);
            var step = new Player().GetNextStep(converted, currentNum);
            Assert.Equal(converted[step[0]][step[1]], 0);
        }
    }
}
