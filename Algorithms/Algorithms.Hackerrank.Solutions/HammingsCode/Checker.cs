using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.HammingsCode
{
    public class Checker:CodeOperator
    {
        public int? Check(bool[] inp)
        {
            var power = 1;
            var hasError = false;
            var errorNum = 0;
            while(inp.Length > power - 1)
            {
                var cur = power;
                power = power << 1;
                var sum = this.CalculateSumm(cur, cur - 1, inp);
                if(sum ==inp[cur - 1]){
                    continue;
                }
                hasError = true;
                errorNum += cur;
            }
            return hasError ? (errorNum - 1):(int?)null;
        }
    }
}
