using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.RangeExtraction;

namespace Algorithms.Implementations.Solutions.TicTacToe
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/57bc5e0471f2ff9233000005/csharp
    /// </summary>
    public class Player
    {

        private class Point
        {
            public int X;
            public int Y;

            public int[] ToArray()
            {
                return new[] { Y, X };
            }
        }

        private static readonly Point[][] _combinations = new Point[][]
        {
            new Point[] {new Point() {X = 0, Y = 0}, new Point() {X = 1, Y = 0}, new Point() {X = 2, Y = 0}},
            new Point[] {new Point() {X = 0, Y = 1}, new Point() {X = 1, Y = 1}, new Point() {X = 2, Y = 1}},
            new Point[] {new Point() {X = 0, Y = 2}, new Point() {X = 1, Y = 2}, new Point() {X = 2, Y = 2}},
            new Point[] {new Point() {X = 0, Y = 0}, new Point() {X = 0, Y = 1}, new Point() {X = 0, Y = 2}},
            new Point[] {new Point() {X = 1, Y = 0}, new Point() {X = 1, Y = 1}, new Point() {X = 1, Y = 2}},
            new Point[] {new Point() {X = 2, Y = 0}, new Point() {X = 2, Y = 1}, new Point() {X = 2, Y = 2}},
            new Point[] {new Point() {X = 0, Y = 0}, new Point() {X = 1, Y = 1}, new Point() {X = 2, Y = 2}},
            new Point[] {new Point() {X = 0, Y = 2}, new Point() {X = 1, Y = 1}, new Point() {X = 2, Y = 0}},

        };


        private int? GetWinner(int[][] board)
        {
            var winnerComb =
                _combinations.FirstOrDefault(c =>
                    board[c[0].Y][c[0].X] != 0 && board[c[0].Y][c[0].X] == board[c[1].Y][c[1].X]
                                               && board[c[0].Y][c[0].X] == board[c[2].Y][c[2].X]);

            if (winnerComb == null)
            {
                return null;
            }

            return board[winnerComb[0].Y][winnerComb[0].X];
        }


        private int GetOppositeNum(int num) => num == 2 ? 1 : 2;

        private int Score(int winner, int num, bool isCurrentPlayer, int depth) => (winner == num && isCurrentPlayer ? 10 - depth : depth - 10);


        private Tuple<Point, int> GetNextTurn(int[][] board, int num, List<int> openPoints, bool isCurrentPlayer, int depth)
        {
            var currentScore = isCurrentPlayer ? Int32.MinValue : Int32.MaxValue;
            Point currentPoint = null;
            var pointsCopy = openPoints.ToList();
            foreach (var index in pointsCopy)
            {
                var point = new Point()
                {
                    Y = index / 3,
                    X = index % 3
                };
                board[point.Y][point.X] = num;
                openPoints.Remove(index);
                var winner = GetWinner(board);

                var rank = !winner.HasValue
                    ? GetNextTurn(board, GetOppositeNum(num),
                        openPoints, !isCurrentPlayer, depth + 1).Item2
                    : Score(winner.Value, num, isCurrentPlayer, depth);
                if ((isCurrentPlayer && rank > currentScore) || (!isCurrentPlayer && rank < currentScore))
                {
                    currentScore = rank;
                    currentPoint = point;
                }

                openPoints.Add(index);
                board[point.Y][point.X] = 0;
            }

            if (currentPoint == null)
            {
                return Tuple.Create((Point)null, 0);
            }

            return Tuple.Create(currentPoint, currentScore);
        }

        public int[] GetNextStep(int[][] board, int num)
        {
            var emptyPoints = this.GetEmptyPoints(board);
            if (emptyPoints.Length > 6)
            {
                if (GetBoardValue(_centerPoint, board) == 0)
                {
                    return _centerPoint.ToArray();
                }
                return GetEmptyCornerPoint(board).ToArray();
            }
            var nextStep = GetNextTurn(board, num,
                emptyPoints.Select(p => p.Y * 3 + p.X).ToList(), true, 0);
            return nextStep.Item1.ToArray();
        }

        private Point[] GetEmptyPoints(int[][] board) => Enumerable.Range(0, 9).Select(i => new Point()
        {
            Y = i / 3,
            X = i % 3
        }).Where((p) => GetBoardValue(p, board) == 0).ToArray();

        private int GetBoardValue(Point point, int[][] board) => board[point.Y][point.X];

        private static readonly Point _centerPoint = new Point()
        {
            X = 1,
            Y = 1
        };

        private Point[] _cornerPoints => new Point[]
        {
            new Point()
            {
                X = 0,
                Y = 0
            },
            new Point()
            {
                X = 2,
                Y = 0
            },
            new Point()
            {
                X = 0,
                Y = 2
            },
            new Point()
            {
                X = 2,
                Y = 2
            }
        };

        private Point GetEmptyCornerPoint(int[][] board)
        {
            return _cornerPoints.FirstOrDefault(p => GetBoardValue(p, board) == 0);
        }

    }
}
