using System.Linq;

namespace Algorithms.Solutions.Implementations.Easy.BirthDayChocolate
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/the-birthday-bar
    /// </summary>
    public class WaysCounter
    {
        private readonly byte[] _chocolate;

        public WaysCounter(byte[] chocolate)
        {
            _chocolate = chocolate;
        }

        public int Count(byte d, byte m)
        {
            if (m > _chocolate.Length || d > m * 5)
            {
                return 0;
            }

            var sum = GetInititalSum(m);
            var count = (sum == d)?1:0;
            for(var i=m; i<_chocolate.Length; i++)
            {
                sum = sum - _chocolate[i-m] + _chocolate[i];
                if (sum == d)
                {
                    count++;
                }
            }

            return count;
        }


        private int GetInititalSum(byte count)
        {
            return _chocolate.Take(count).Sum(x=>x);
        }
    }
}
