using System;
using System.Linq;

namespace Algorithms.Implementations.Solutions.IQTest
{
    public class NumberSearcher
    {
        public int GetPositionOfDifferentNumber(string inp)
        {
            var groups = inp.Split(' ').Select((v, i) => new {v = Int32.Parse(v), i}).GroupBy(x => x.v % 2)
                .OrderBy(g => g.Count()).Select(g => g.FirstOrDefault())
                .ToList();
            return groups.Count < 2 ? -1 : groups[0].i + 1;
        }
    }
}
