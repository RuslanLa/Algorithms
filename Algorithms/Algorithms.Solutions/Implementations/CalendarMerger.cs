using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Solutions.Implementations
{
    public class CalendarMerger
    {
        public class ActivityInfo
        {
            public ActivityInfo(int startTime, int endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }
            public int StartTime { get; }

            public int EndTime { get; }

            public override bool Equals(object obj)
            {
                if (!(obj is ActivityInfo activityInfo))
                {
                    return false;
                }

                return activityInfo.StartTime == StartTime && activityInfo.EndTime == EndTime;
            }

            public override int GetHashCode()
            {
                return StartTime ^ EndTime;
            }
        }

        public IList<ActivityInfo> Merge(IEnumerable<ActivityInfo> activities)
        {
            var sorted = activities.OrderBy(x => x.StartTime).ToArray();
            if (sorted.Length == 0)
            {
                throw new ArgumentException("Input activities length should be greater than 0");
            }

            var biggestEndTime = sorted[0].EndTime;
            var lestStartTime = sorted[0].StartTime;
            var result = new List<ActivityInfo>();

            void AddBiggest() => result.Add(new ActivityInfo(lestStartTime, biggestEndTime));
            for (var i = 1; i < sorted.Length; i++)
            {
                var current = sorted[i];
                var currentStartTime = current.StartTime;
                var currentEndTime = current.EndTime;
                if (biggestEndTime > currentEndTime)
                {
                    continue;
                }

                if (biggestEndTime >= currentStartTime)
                {
                    biggestEndTime = currentEndTime;
                    continue;
                }

                AddBiggest();
                biggestEndTime = currentEndTime;
                lestStartTime = currentStartTime;
            }
            AddBiggest();
            return result;
        }
    }
}
