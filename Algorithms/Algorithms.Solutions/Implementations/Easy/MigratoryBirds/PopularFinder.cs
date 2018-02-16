using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.Implementations.Easy.MigratoryBirds
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/migratory-birds solution
    /// </summary>
    public class PopularFinder
    {
        private readonly byte _typesCount;
        public PopularFinder(byte typesCount)
        {
            _typesCount = typesCount;
        }

        public byte GetType(IEnumerable<byte> birds)
        {
            var helper = new int[_typesCount];
            byte mustPopularType = 0;
            foreach(var bird in birds.Select(b=>(byte)(b-1)))
            {
                helper[bird]++;
                var curTypeCount = helper[bird];
                var mustPopularCount = helper[mustPopularType];
                if (curTypeCount < mustPopularCount)
                {
                    continue;
                }

                if (curTypeCount == mustPopularCount)
                {
                    if(bird >= mustPopularType)
                    {
                        continue;
                    }
                }

                mustPopularType = bird;
            }

            return (byte)(mustPopularType+1);
        }
    }
}
