using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions.LastDigitOfHugeNumber
{
    public class Calculator
    {
        private class ModRule
        {
            public int[] EvenRules;
            public int[] OddRules;
        }
        public int GetLastDigit(int[] powers)
        {
            if (powers.Length == 1 && powers[0] == 0)
            {
                return 1;
            }
            if (powers.Length == 0)
            {
                return 1;
            }

            powers = Compress(powers);

            var possibleRemainders = _remainders[powers[0] % 10];

            if (possibleRemainders.Length == 1)
            {
                return possibleRemainders[0];
            }

            if (possibleRemainders.Length == 2)
            {
                return possibleRemainders[Module2(powers, 0)];
            }

            return possibleRemainders[Module4(powers, 0)];
        }

        private int[] Compress(int[] powers)
        {
            var compressed = new Stack<int> { };
            var isPreviousZero = false;
            for (int i = powers.Length - 1; i > 0; i--)
            {
                if (isPreviousZero || powers[i] == 1)
                {
                    compressed = new Stack<int> { };
                    isPreviousZero = false;
                    continue;
                }

                if (powers[i] == 0)
                {
                    isPreviousZero = true;
                    continue;
                }

                compressed.Push(powers[i]);
            }

            if (isPreviousZero)
            {
                return new int[] { 1 };
            }

            compressed.Push(powers[0]);
            return compressed.ToArray();
        }

        private int Module2(int[] powers, int powersIndex) => GetPowerAtIndex(powers, powersIndex + 1) % 2;

        private int Module4(int[] powers, int powersIndex)
        {
            var nextIndex = powersIndex + 1;
            var nextValue = GetPowerAtIndex(powers, nextIndex);
            var lastDigit = nextValue % 10;
            var secondLastDigit = (nextValue % 100) / 10;
            var isSecondLastDigitEven = secondLastDigit % 2 == 0;
            var rule = _mod4Rules[lastDigit];
            var isDigitEven = lastDigit % 2 == 0;
            var nextPower = GetPowerAtIndex(powers, nextIndex + 1);
            var specialCaseArray = rule.EvenRules.Length > 1 ? rule.EvenRules : rule.OddRules;
            if (isSecondLastDigitEven && rule.EvenRules.Length == 1)
            {
                return rule.EvenRules[0];
            }
            if (!isSecondLastDigitEven && rule.OddRules.Length == 1)
            {
                return rule.OddRules[0];
            }
            if (isDigitEven)
            {
                return specialCaseArray[nextPower == 1 ? 0 : 1];
            }

            return specialCaseArray[nextPower % 2];
        }

        private int GetPowerAtIndex(int[] powers, int index) => index >= powers.Length ? 1 : powers[index];

        private int[][] _remainders = new int[][]
        {
            new []{0},
            new []{1},
            new []{6, 2, 4, 8},
            new []{1, 3, 9, 7},
            new []{6, 4},
            new []{5},
            new []{6},
            new []{1, 7, 9, 3},
            new []{6, 8, 4, 2},
            new []{1, 9}
        };

        private ModRule[] _mod4Rules = {
            new ModRule()
            {
                EvenRules = new []{0},
                OddRules = new []{2, 0}
            },
            new ModRule()
            {
                EvenRules = new []{1},
                OddRules = new []{1, 3}
            },
            new ModRule()
            {
                EvenRules = new []{2, 0},
                OddRules = new []{0}
            },
            new ModRule()
            {
                EvenRules = new []{1, 3},
                OddRules = new []{1}
            },
            new ModRule()
            {
                EvenRules = new []{0},
                OddRules = new []{2, 0}
            },
            new ModRule()
            {
                EvenRules = new []{1},
                OddRules = new []{1, 3}
            },
            new ModRule()
            {
                EvenRules = new []{2, 0},
                OddRules = new []{0}
            },
            new ModRule()
            {
                EvenRules = new []{1, 3},
                OddRules = new []{1}
            },
            new ModRule()
            {
                EvenRules = new []{0},
                OddRules = new []{2, 0}
            },
            new ModRule()
            {
                EvenRules = new []{1},
                OddRules = new []{1, 3}
            },
        };
    }
}
