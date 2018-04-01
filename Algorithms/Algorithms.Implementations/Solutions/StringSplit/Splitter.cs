using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.StringSplit
{
    /// <summary>
    /// Solution for the Kata https://www.codewars.com/kata/515de9ae9dcfc28eb6000001/
    /// </summary>
    public class Splitter
    {
        public string[] Split(string input)
        {
            return input.Select((v, i) => new {v, i})
                .GroupBy(x => x.i / 2).Select(g => g.Select(x => x.v).ToArray()).Select(x => x.Length == 1
                    ? new[]
                    {
                        x[0],
                        '_'
                    }
                    : x).Select(x => String.Join("", x)).ToArray();
        }
    }
}
