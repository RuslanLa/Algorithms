using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.HammingsCode
{
    public class Encoder: CodeOperator
    {
        public bool[] Encode(bool[] arr)
        {
            var prefilled = GetPrefilledArray(arr);
            var power = 1;
            for(var i=0; i < prefilled.count; i++)
            {
                prefilled.arr[power - 1] = this.CalculateSumm(power, power-1, prefilled.arr);
                power = power << 1;
            }
            return prefilled.arr;
            
        }
        private (bool[] arr, int count) GetPrefilledArray(bool[] arr)
        {
            var result = new List<bool>() { false, false };
            var nextPower = 4;
            var i = 0;
            var powersCount = 2;
            while (i<arr.Length)
            {
                if(result.Count == nextPower-1)
                {
                    result.Add(false);
                    powersCount++;
                    nextPower = nextPower << 1;
                    continue;
                }

                result.Add(arr[i]);
                i++;
            }
           return (result.ToArray(), powersCount);
        }
    }
}