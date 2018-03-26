namespace Algorithms.Implementations.Solutions.Graphics
{
    /// <summary>
    /// Solution for http://www.codewars.com/kata/569e0778f3b6ef81b7000046/csharp
    /// </summary>
    public static class Drawer
    {
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
    }
}
