//using System.Collections.Generic;
//using System.Linq;

////Implementation of http://www.codewars.com/kata/graphics-02-drawing-circles
//namespace smile67Kata
//{
//    using System;
//    public class Kata
//    {
//        public class Point
//        {
//            public Point(int x, int y)
//            {
//                X = x;
//                Y = y;
//            }
//            public Point(double x, double y)
//            {
//                if (x < Int32.MaxValue && x > Int32.MinValue)
//                {
//                    X = (int)Math.Round(x);
//                }

//                if (y < Int32.MaxValue && x > Int32.MinValue)
//                {
//                    Y = (int)Math.Round(y);
//                }
//            }
//            public int X { get; }
//            public int Y { get; }
//            public override bool Equals(object obj)
//            {
//                if (!(obj is Point))
//                {
//                    return false;
//                }

//                var point = obj as Point;
//                return point.X == this.X && point.Y == this.Y;
//            }

//            public override int GetHashCode()
//            {
//                return X ^ Y;
//            }

//            public Point CorrectToCenter(Point center)
//            {
//                return new Point(X + center.X, Y + center.Y);
//            }

//            public Point Project()
//            {
//                return new Point(X, -Y);
//            }
//        }

//        public static bool[,] Line(int x1, int y1, int x2, int y2)
//        {
//            var coeffeicient = CalculateCoeffecient(x1, y1, x2, y2);
//            var summand = CalculateSummand(x1, y1, coeffeicient);
//            var result = new bool[100, 50];
//            var minX = x2 > x1 ? x1 : x2;
//            var maxX = x1 >= x2 ? x1 : x2;
//            var xFrom = minX <= 0 ? 0 : minX;
//            var xTo = maxX >= 100 ? 100 : maxX;
//            for (var x = xFrom; x < xTo; x++)
//            {
//                var y = (int)(coeffeicient * x + summand);
//                if (y >= 50)
//                {
//                    continue;
//                }

//                result[x, y] = true;
//            }

//            return result;
//        }

//        private static double CalculateCoeffecient(int x1, int y1, int x2, int y2)
//        {
//            return ((double)y1 - y2) / ((double)x1 - x2);
//        }
//        private static double CalculateSummand(int x1, int y1, double k)
//        {
//            return y1 - k * x1;
//        }


//        private static bool IsPointHidden(int x, int y)
//        {
//            return x > 99 || x < 0 || y > 49 || y < 0;
//        }

//        private static Point GetCirclePointsForTheta(Point center, int theta, int r)
//        {
//            double x = center.X + r * Math.Cos(theta * Math.PI / 180);
//            double y = center.Y + r * Math.Sin(theta * Math.PI / 180);
//            return new Point(x, y);
//        }

//        public static IEnumerable<Point> GetVisiblePartOfCircle(int x, int y, int r)
//        {
//            return GetAllCirclePoints(x, y, r).Where(p => !IsPointHidden(p.X, p.Y));
//        }

//        private static IEnumerable<Point> GetAllCirclePoints(int x, int y, int r)
//        {
//            var newCenter = new Point(x, y).Project();
//            return Enumerable.Range(0, 360).Select(i => GetCirclePointsForTheta(newCenter, i, r))
//                .Select(p => p.Project()).Distinct();
//        }


//        public void drawCircle(int x, int y, int r)
//        {
//            foreach (var point in GetVisiblePartOfCircle(x, y, r))
//            {
//                Drawing.Canvas[point.X, point.Y] = true;
//            }
//        }
//    }
//}