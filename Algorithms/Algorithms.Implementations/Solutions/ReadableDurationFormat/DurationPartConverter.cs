using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.ReadableDurationFormat
{
    public static class DurationPartConverter
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
}
