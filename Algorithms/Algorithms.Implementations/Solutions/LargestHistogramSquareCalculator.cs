using System;
using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions
{
    /// <summary>
    /// Implementation of calculation square of a biggest rectangle from a histogram
    /// (https://www.youtube.com/watch?v=VNbkzsnllsU)
    /// Just for fun quick implementation
    /// </summary>
    public class LargestHistogramSquareCalculator
    {
        private class Point
        {
            public int Vertical { get; set; }
            public int Horizontal { get; set; }
            public static Lazy<Point> NullPoint => new Lazy<Point>(()=>new Point(){Horizontal = 0, Vertical = 0});
        }

        /// <summary>
        /// Calculates the square of rectangle
        /// </summary>
        /// <param name="endPos"></param>
        /// <param name="startPos"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private int Square(int endPos, int startPos, int height) => (endPos - startPos) * height;

        /// <summary>
        /// Calculates maximum from current rectangle square and the biggest square
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        /// <param name="previousBiggest"></param>
        /// <returns></returns>
        private int GetBiggestSquare(Stack<Point> points, int position, int previousBiggest)
        {
            var lastPoint = points.Pop();
            var square = Square(position, lastPoint.Horizontal, lastPoint.Vertical);
            return Math.Max(previousBiggest, square);
        }

        /// <summary>
        /// Iterates the stack until the end or until the point.height bigger than height
        /// and returns biggest square from iterated points and the previousBiggest
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        /// <param name="previousBiggest"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private int GetBiggestSquareFromStack(Stack<Point> points, int position, int previousBiggest, int height)
        {
            while (points.Count > 0)
            {
                var lastPoint = points.Peek();
                if (lastPoint.Vertical <= height)
                {
                    break;
                }
                previousBiggest = GetBiggestSquare(points, position, previousBiggest);
            }
            return previousBiggest;
        }

        private void AssertHistogramIsValid(int[] histogram)
        {
            if (histogram == null || histogram.Length == 0)
            {
                throw new Exception("Expected non empty histogram");
            }
        }

        public int Calculate(int[] histogram)
        {
            AssertHistogramIsValid(histogram);
            var points = new Stack<Point>();
            var biggestSquare = 0;
            for (int pos = 0; pos < histogram.Length; pos++)
            {
                var height = histogram[pos];
                var lastPoint = points.Count > 0 ? points.Peek():Point.NullPoint.Value;
                if (height == lastPoint.Vertical)
                {
                    continue;
                }
                if (points.Count != 0 && height <= lastPoint.Vertical)
                {
                    biggestSquare = GetBiggestSquareFromStack(points, pos, biggestSquare, height);
                }
                points.Push(new Point() { Horizontal = pos, Vertical = height });
            }

           biggestSquare = GetBiggestSquareFromStack(points, histogram.Length, biggestSquare, 0);

            return biggestSquare;
        }
    }
}
