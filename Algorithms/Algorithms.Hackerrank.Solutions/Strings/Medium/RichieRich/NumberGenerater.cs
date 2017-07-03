using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hackerrank.Solutions.Strings.Medium.RichieRich
{
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/richie-rich
    /// </summary>
    public class NumberGenerater
    {
        /// <summary>
        /// Generates max palindrome
        /// </summary>
        /// <param name="input"></param>
        /// <param name="possibleChanges"></param>
        /// <returns></returns>
        public string Generate(string input, int possibleChanges)
        {
            var isOne = CheckIsOneItemInLastPair(input.Length);
            var pairsCount = GetPairsCount(input.Length, isOne);
            var pairs = input.Select((v, i) => new
                    { i, v }).GroupBy(x => x.i < pairsCount ? x.i : input.Length - x.i - 1)
                .Select(g => new BytePair(g.Select(x => x.v).ToArray(), g.Key, pairsCount, isOne)).ToArray();
            var notEqualsCount = pairs.Count(p => !p.IsEqual);
            if (notEqualsCount > possibleChanges)
            {
                return "-1";
            }

            var polindrom = this.GetPolindrom(pairs, notEqualsCount, possibleChanges);
            return String.Join("", polindrom);
        }

        private int GetPairsCount(int inputLength, bool isOne) => inputLength / 2 + (isOne ? 1 : 0);

        private bool CheckIsOneItemInLastPair(int inputLength) => inputLength % 2 == 1;

        private IEnumerable<byte> GetPolindrom(BytePair[] pairs, int notEqualPairsCount, int actionsConstraint)
        {
            var ninesCount = actionsConstraint - notEqualPairsCount;
            var lastPair = pairs.Last();
            var stack = new Stack<byte>();
            var list = new List<byte>();
            foreach (var pair in pairs)
            {
                byte item;
                if (ninesCount > 0 && TrySetNineInPair(pair, ref ninesCount, lastPair))
                {
                    item = pair.FirstItem;
                }
                else
                {
                    item = pair.FirstItem > pair.SecondItem ? pair.FirstItem : pair.SecondItem;
                }
                list.Add(item);
                if (pair.ContainsSecondItem)
                {
                    stack.Push(item);
                }
            }

            return list.AsEnumerable().Concat(stack.AsEnumerable());
        }

        private bool TrySetNineInPair(BytePair pair, ref int ninesCount, BytePair lastPair)
        {
            if (pair.FirstItem == 9 || pair.SecondItem == 9)
            {
                if (pair.IsEqual)
                {
                    return true;
                }
                pair.SetPairValue(9);
                return true;
            }
            var operationsCount = !pair.ContainsSecondItem || !pair.IsEqual ? 1 : 2;
            if (ninesCount < operationsCount)
            {
                if (!lastPair.ContainsSecondItem)
                {
                    lastPair.SetPairValue(9);
                }
                ninesCount = 0;
                return false;
            }
            pair.SetPairValue(9);
            ninesCount = ninesCount - operationsCount;
            return true;
        }

    }
}
