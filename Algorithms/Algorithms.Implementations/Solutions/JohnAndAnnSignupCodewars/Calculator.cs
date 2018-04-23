using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.JohnAndAnnSignupCodewars
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/john-and-ann-sign-up-for-codewars
    /// </summary>
    public class Calculator
    {
        public List<long> John(long n)
        {
            var ann = new long[n];
            var john = new long[n];
            FillBoth(ann, john);
            return new List<long>(john);
        }

        private void FillNth(long[] currentPerson, long[] another, int n) => currentPerson[n] = n+1 - another[currentPerson[n - 1]];

        private void FillBoth(long[] ann, long[] john)
        {
            ann[0] = 1;
            john[0] = 0;

            for (var i = 1; i < ann.Length; i++)
            {
                FillNth(john, ann, i);
                FillNth(ann, john, i);
            }
        }

        public List<long> Ann(long n)
        {
            var ann = new long[n];
            var john = new long[n];
            FillBoth(ann, john);
            return new List<long>(ann);
        }

        public long SumJohn(long n)
        {
            return John(n).Sum();
        }

        public long SumAnn(long n)
        {
            return Ann(n).Sum();
        }
    }
}
