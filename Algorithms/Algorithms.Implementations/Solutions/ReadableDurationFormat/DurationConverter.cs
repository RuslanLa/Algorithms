using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.ReadableDurationFormat
{
    public static class DurationConverter
    {
        private static DurationPartMetadata[] _partMetadatas = new DurationPartMetadata[]
        {
            DurationPartValues.Year,
            DurationPartValues.Day,
            DurationPartValues.Hour,
            DurationPartValues.Minute,
            DurationPartValues.Second
        };

        private static bool IsNow(int seconds) => seconds == 0;

        public static string ToUserFriendlyFormat(int seconds)
        {
            if (IsNow(seconds))
            {
                return "now";
            }

            var result = new List<string>();
            FillDatePartsList(result, seconds);
            return ConcatDateParts(result);
        }

        private static void FillDatePartsList(List<string> dateParts, int seconds)
        {
            foreach (var metadata in _partMetadatas)
            {
                var partValue = seconds / metadata.Divisor;
                if (partValue == 0)
                {
                    continue;
                }
                var value = DurationPartConverter.ToString(metadata, partValue);
                dateParts.Add(value);
                seconds = seconds % metadata.Divisor;
            }
        }

        private static string ConcatDateParts(List<string> dateParts)
        {
            if (dateParts.Count == 1)
            {
                return dateParts[0];
            }

            var lastTwoParts = String.Join(" and ", dateParts.Skip(dateParts.Count - 2));
            return String.Join(", ", dateParts.Take(dateParts.Count - 2).Concat(new[] { lastTwoParts }));
        }
    }
}
