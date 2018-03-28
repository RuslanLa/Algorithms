//using System.Collections.Generic;
//using System.Linq;

//namespace smile67Kata
//{
//    using System;
//    public class Kata
//    {
//        private class Point
//        {
//            public Point(int x, int y)
//            {
//                X = x;
//                Y = y;
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
//        }

//        private static bool IsPointHidden(int x, int y)
//        {
//            return x > 100 || x < 0 || y > 50 || y < 0;
//        }

//        private static IEnumerable<Point> GetCirclePointsForX(int xCenter, int yCenter, int x, int r)
//        {
//            var yPoint = (int)Math.Sqrt(r * r - x * x);
//            yield return new Point(x, yPoint);
//            yield return new Point((xCenter - x) + xCenter, yPoint);
//            yield return new Point(x, (yCenter - yPoint) + yCenter);
//            yield return new Point((xCenter - x) + xCenter, (yCenter - yPoint) + yCenter);
//        }

//        private static IEnumerable<Point> GetVisiblePartOfCircle(int x, int y, int r)
//        {
//            return GetAllCirclePoints(x, y, r).Where(p => !IsPointHidden(p.X, p.Y));
//        }

//        private static IEnumerable<Point> GetAllCirclePoints(int x, int y, int r)
//        {
//            return Enumerable.Range(x - r, r + 1).SelectMany(i => GetCirclePointsForX(x, y, i, r)).Distinct();
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