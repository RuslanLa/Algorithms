using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Implementations.Solutions.Graphics
{
    /// <summary>
    /// Solution for http://www.codewars.com/kata/569e0778f3b6ef81b7000046/csharp
    /// </summary>
    public static class Drawer
    {
        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public  int X { get;}
            public int Y { get; }
            public override bool Equals(object obj)
            {
                if (!(obj is Point))
                {
                    return false;
                }

                var point = obj as Point;
                return point.X == this.X && point.Y == this.Y;
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }
        }

        public static bool[,] Line(int x1, int y1, int x2, int y2)
        {
            var coeffeicient = CalculateCoeffecient(x1, y1, x2, y2);
            var summand = CalculateSummand(x1, y1, coeffeicient);
            var result = new bool[100, 50];
            var minX = x2 > x1 ? x1 : x2;
            var maxX = x1 >= x2 ? x1 : x2;
            var xFrom = minX <= 0 ? 0 : minX;
            var xTo = maxX >= 100 ? 100 : maxX;
            for (var x = xFrom; x < xTo; x++)
            {
                var y = (int)(coeffeicient * x + summand);
                if (y >= 50)
                {
                    continue;
                }

                result[x, y] = true;
            }

            return result;
        }

        private static double CalculateCoeffecient(int x1, int y1, int x2, int y2)
        {
            return ((double)y1 - y2)/ ((double)x1 - x2);
        }
        private static double CalculateSummand(int x1, int y1, double k)
        {
            return y1 - k * x1;
        }


        private static bool IsPointHidden(int x, int y)
        {
            return x > 100 || x < 0 || y > 50 || y < 0;
        }

        private static IEnumerable<Point> GetCirclePointsForX(int xCenter, int yCenter, int x, int r)
        {
            var yPoint = (int)Math.Sqrt(r*r - x * x);
            yield return new Point(x, yPoint);
            yield return new Point((xCenter - x) + xCenter, yPoint);
            yield return new Point(x, (yCenter - yPoint) + yCenter);
            yield return new Point((xCenter - x) + xCenter, (yCenter - yPoint) + yCenter);
        }

        public static IEnumerable<Point> GetVisiblePartOfCircle(int x, int y, int r)
        {
            return GetAllCirclePoints(x, y, r).Where(p => !IsPointHidden(p.X, p.Y));
        }

        private static IEnumerable<Point> GetAllCirclePoints(int x, int y, int r)
        {
            return Enumerable.Range(x - r, r + 1).SelectMany(i => GetCirclePointsForX(x, y, i, r)).Distinct();
        }
    }
}
