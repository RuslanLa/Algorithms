using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/human-readable-duration-format/train/csharp
/// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
/// There is more suitable for unit-testing class - DurationConverter
/// </summary>
public class HumanTimeFormat
{
    private class DurationPartMetadata
    {
        public DurationPartMetadata(string singleForm, string pluralForm, int divisor)
        {
            SingleForm = singleForm;
            PluralForm = pluralForm;
            Divisor = divisor;
        }

        public string SingleForm { get; }
        public string PluralForm { get; }
        public int Divisor { get; }
    }

    private static class DurationPartConverter
    {
        public static string ToString(DurationPartMetadata metadata, int value)
        {
            if (value == 0)
            {
                return String.Empty;
            }

            var form = metadata.PluralForm;
            if (value == 1)
            {
                form = metadata.SingleForm;
            }

            return $"{value} {form}";
        }
    }

    private class DurationPartValues
    {
        public static readonly DurationPartMetadata Minute = new DurationPartMetadata("minute", "minutes", 60);
        public static readonly DurationPartMetadata Second = new DurationPartMetadata("second", "seconds", 1);
        public static readonly DurationPartMetadata Hour = new DurationPartMetadata("hour", "hours", 60 * 60);
        public static readonly DurationPartMetadata Day = new DurationPartMetadata("day", "days", 24 * 60 * 60);

        public static readonly DurationPartMetadata
            Year = new DurationPartMetadata("year", "years", 24 * 60 * 60 * 365);
    }

    private static DurationPartMetadata[] _partMetadatas = new DurationPartMetadata[]
    {
        DurationPartValues.Year,
        DurationPartValues.Day,
        DurationPartValues.Hour,
        DurationPartValues.Minute,
        DurationPartValues.Second
    };

    private static bool IsNow(int seconds) => seconds == 0;

    private static string ToUserFriendlyFormat(int seconds)
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

    public static string formatDuration(int seconds)
    {
        return ToUserFriendlyFormat(seconds);
    }
}