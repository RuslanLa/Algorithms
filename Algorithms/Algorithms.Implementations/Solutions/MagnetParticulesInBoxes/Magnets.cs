using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.MagnetParticulesInBoxes
{
    public class Magnets
    {
        public double Doubles(int maxk, int maxn)
        {
            double sum = 0;
            for (int i = 1; i <= maxk; i++)
            {
                for (int j = 1; j <= maxn; j++)
                {
                    sum += (double) 1 / (i * Math.Pow(j + 1, 2*i));
                }
            }

            return sum;
        }
    }
}
