using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Solutions.Implementations;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.HackerRankSolutions
{
    public class CalendarMergerTests
    {
        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]
                {
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(1, 2)
                    },
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(1, 2)
                    }
                },
                new object[]
                {
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(1, 3),
                        new CalendarMerger.ActivityInfo(2, 4)
                    },
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(1, 4)
                    }
                },
                new object[]
                {
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(0, 1),
                        new CalendarMerger.ActivityInfo(3, 5),
                        new CalendarMerger.ActivityInfo(4, 8),
                        new CalendarMerger.ActivityInfo(10, 12),
                        new CalendarMerger.ActivityInfo(9, 10)
                    },
                    new[]
                    {
                        new CalendarMerger.ActivityInfo(0, 1),
                        new CalendarMerger.ActivityInfo(3, 8),
                        new CalendarMerger.ActivityInfo(9, 12)
                    }
                }
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        private readonly CalendarMerger _calendarMerger = new CalendarMerger();

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void MergeTest(CalendarMerger.ActivityInfo[] activityInfo,
            CalendarMerger.ActivityInfo[] expectedOutput)
        {
            var mergingResult = _calendarMerger.Merge(activityInfo);
            mergingResult.Select((v, i)=> new {v, i}).ShouldAllBe(o => o.v.Equals(expectedOutput[o.i]));
        }
    }
}
