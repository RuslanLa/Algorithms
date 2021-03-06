﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.SquareDecomposition
{
    /// <summary>
    /// Solution for KATA
    /// https://www.codewars.com/kata/square-into-squares-protect-trees
    /// </summary>
    public class Decomposer
    {
        public string Decompose(long n)
        {
            var decomposition = Decompose(n, n * n);
            return decomposition != null ? String.Join(" ", decomposition.Take(decomposition.Count - 1)) : null;
        }

        private List<long> Decompose(long n, long remain)
        {
            if (remain == 0)
            {
                return new List<long> {n};
            }

            for (var i = n - 1; i > 0; i--)
            {
                if (remain - i * i < 0)
                {
                    continue;
                }

                var addition = Decompose(i, remain - i * i);
                if (addition == null)
                {
                    continue;
                }

                addition.Add(n);
                return addition;
            }

            return null;
        }

    }
}
