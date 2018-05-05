using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.WeightForWeight
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/55c6126177c9441a570000cc
    /// </summary>
    public class WeightListManager
    {
        public string Reorder(string input)
        {
            return String.Join(" ", input.Split(' ').Select(x => x.Trim()).Select(x => new
            {
                num = x,
                sum = CalculateDigitsSum(x)
            }).OrderBy(x => x.sum).ThenBy(x => x.num).Select(x => x.num));
        }

        private int CalculateDigitsSum(string number)
        {
            var sum = 0;
            foreach (var digit in number.Select(x=>(int)Char.GetNumericValue(x)))
            {
                sum = sum * 10 + digit;
            }

            return sum;
        }
    }
}
