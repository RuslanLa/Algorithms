using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.ReadableDurationFormat
{
    public class DurationPartValues
    {
        public static readonly DurationPartMetadata Minute = new DurationPartMetadata("minute", "minutes", 60);
        public static readonly DurationPartMetadata Second = new DurationPartMetadata("second", "seconds", 1);
        public static readonly DurationPartMetadata Hour = new DurationPartMetadata("hour", "hours", 60*60);
        public static readonly DurationPartMetadata Day = new DurationPartMetadata("day", "days", 24*60*60 );
        public static readonly DurationPartMetadata Year = new DurationPartMetadata("year", "years", 24*60*60*365);
    }
}
