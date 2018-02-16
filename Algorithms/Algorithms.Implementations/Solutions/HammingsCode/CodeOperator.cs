namespace Algorithms.Implementations.Solutions.HammingsCode
{
    public class CodeOperator
    {
        protected bool CalculateSumm(int summNum, int start, bool[] arr)
        {
            var trueCounts = 0;
            var cur = start + 1;
            var taken = 1;
            while (cur < arr.Length)
            {
                if (taken == summNum)
                {
                    cur = cur + summNum;
                    taken = 0;
                    continue;
                }

                if (arr[cur])
                {
                    trueCounts++;
                }
                taken++;
                cur++;
            }

            return trueCounts % 2 == 1;
        }
    }
}
