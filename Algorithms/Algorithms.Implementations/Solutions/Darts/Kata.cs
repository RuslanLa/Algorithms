using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/lets-play-darts/train/csharp
/// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
/// There is more suitable for unit-testing class - ScoreCalculator
/// </summary>
public class Dartboard
{
    public string GetScore(double x, double y)
    {
       return new ScoreCalculator().Calculate(x, y);
    }
    public class ScoreCalculator
    {
        private class Sector
        {
            public double From { get; set; }
            public double To { get; set; }
            public string Value { get; set; }
            public bool NeedSlice { get; set; }

            public bool IsContains(double quadraticDistance)
            {
                return quadraticDistance >= Math.Pow(From / 2, 2) &&
                       (To == Double.MaxValue || Math.Pow(To / 2, 2) >= quadraticDistance);
            }
        }
        private static readonly IReadOnlyList<int> _slices = new List<int>()
        {
            20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5
        };

        private static readonly IReadOnlyList<Sector> _sectors = new List<Sector>()
        {
            new Sector { From =  0, To =  12.7, Value =  "DB"},
            new Sector { From =  12.7, To =  31.8, Value =  "SB"},
            new Sector { From =  198, To =  214, Value =  "T", NeedSlice =  true},
            new Sector {From = 324, To =  340, Value = "D", NeedSlice =  true},
            new Sector {From = 340, To = Double.MaxValue, Value = "X"},
        };
        public string Calculate(double x, double y)
        {
            if (x == 0 && y == 0)
            {
                return "DB";
            }

            var distance = x * x + y * y;
            var sector = _sectors.FirstOrDefault(s => s.IsContains(distance));
            if (sector == null)
            {
                return CalculateSlices(x, y).ToString();
            }
            if (!sector.NeedSlice)
            {
                return sector.Value;
            }
            return $"{sector.Value}{CalculateSlices(x, y)}";

        }

        private int CalculateSlices(double x, double y)
        {
            var degree = GetDegree(x, y);
            var rotate = (degree + 9) % 360;
            var sliceIndex = (int)rotate / 18;
            return _slices[sliceIndex];
        }

        private double GetDegree(double x, double y)
        {
            double radians = Math.Atan2(x, y);

            var degree = radians * 180 / System.Math.PI;
            if (degree < 0)
            {
                degree += 360;
            }

            return degree;
        }


    }
}