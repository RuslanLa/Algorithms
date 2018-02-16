using System;

namespace Algorithms.Implementations.Solutions.DayOfTheProgrammer
{
    /// <summary>
    /// Solution for the challenge https://www.hackerrank.com/challenges/day-of-the-programmer
    /// </summary>
    public class ProgrammerDay
    {
        private readonly ushort _year;
        private static readonly ushort _gregoriansBegin = 1918;
        private static readonly string _dateFormat="{0}.{1}";
        private static readonly string _leapYearDate = "12.09";
        private static readonly string _notLeapYearDate = "13.09";
        private static readonly string _gregorianBeginDate="31.08";

        public ProgrammerDay(ushort year)
        {
            _year = year;
        }

        private bool _isGregorian
        {
            get
            {
               return _year > 1918;
            }
        }

        private bool _isLeapYear
        {
            get
            {

                var isFourDivisible = _year % 4 == 0;
                if (!_isGregorian)
                {
                    return isFourDivisible;
                }

                return (isFourDivisible && _year % 100 != 0) || _year % 400 == 0;
            }
        }

        private string _monthAndDay
        {
            get
            {
                if (_year == 1918)
                {
                    return _gregorianBeginDate;
                }

                return _isLeapYear ? _leapYearDate : _notLeapYearDate;
            }
        }

        public string Date
        {
            get
            {
                return String.Format(_dateFormat, _monthAndDay, _year);
            }
        }
    }
}
