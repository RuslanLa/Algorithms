using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Algorithms.Hackerrank.Solutions.Implementations.Easy.SwimmingPool
{
    public class WaterCounter
    {
        public int Count(int[] pool)
        {
            if (pool.Length < 3)
            {
                return 0;
            }

            var edges = this.GetEdges(pool);
            if (!edges.found)
            {
                return 0;
            }

            bool isLeftBigger = pool[edges.left] >= pool[edges.right];
            var volume = 0;
            var min = isLeftBigger ? pool[edges.right] : pool[edges.left];
            var max = isLeftBigger ? pool[edges.left] : pool[edges.right];
            while (edges.left < edges.right)
            {
                var cur = isLeftBigger ? pool[edges.right] : pool[edges.left];
                if (cur > min)
                {
                    if (cur > max)
                    {
                        isLeftBigger = !isLeftBigger;
                        min = max;
                        max = cur;
                    }
                    else
                    {
                        min = cur;
                    }
                }
                else
                {
                    volume += min - (isLeftBigger ? pool[edges.right] : pool[edges.left]);
                }
                if (isLeftBigger)
                {
                    edges.right--;
                }
                else
                {
                    edges.left++;
                }
            }
            return volume;
        }

        private (int left, int right, bool found) GetEdges(int[] pool)
        {
            var left = 0;
            var right = pool.Length - 1;
            var leftFound = false;
            var rightFound = false;
            while (left != right)
            {
                if (pool[left] > pool[left + 1])
                {
                    leftFound = true;
                }

                if (pool[right] > pool[right - 1])
                {
                    rightFound = true;
                }

                right = (!rightFound) ? right-1 : right;
                left = (!leftFound) ? left+1 : left;

                if(rightFound && leftFound)
                {
                    break;
                }
            }


            return (left, right, leftFound && rightFound);
        }
    }
}