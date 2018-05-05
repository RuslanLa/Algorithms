using System.Linq;

namespace Algorithms.Implementations.Solutions.EqualSidesOfAnArray
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/equal-sides-of-an-array
    /// </summary>
    public class IndexFinder
    {
        public int FindIndexOfSplit(int[] array)
        {
            var leftSum = 0;
            var rightSum = array.Sum();
            for (var i = 0; i < array.Length; i++)
            {
                rightSum -= array[i];
                if (rightSum == leftSum)
                {
                    return i;
                }

                leftSum += array[i];
            }
            return -1;
        }
    }
}
