using System;

namespace Algorithms.Implementations.Solutions.Strings.Medium.RichieRich
{
    /// <summary>
    /// Helper structure
    /// Pare of byte values
    /// </summary>
    public class BytePair
    {
        public byte FirstItem { get; private set; }
        public byte SecondItem { get; private set; }
        public readonly int PairNum;
        public readonly bool ContainsSecondItem;
        public bool IsEqual { get; private set; }

        public BytePair(char[] pair, int pairNum, int pairsCount, bool isOneItemLastPair)
        {
            ContainsSecondItem = (pairNum != pairsCount - 1) || !isOneItemLastPair;
            FirstItem = Byte.Parse(pair[0].ToString());
            if (ContainsSecondItem)
            {
                SecondItem = Byte.Parse(pair[1].ToString());
            }
            PairNum = pairNum;
            IsEqual = !ContainsSecondItem || FirstItem == SecondItem;
        }

        public void SetPairValue(byte value)
        {
            FirstItem = SecondItem = value;
            IsEqual = true;
        }
    }
}
