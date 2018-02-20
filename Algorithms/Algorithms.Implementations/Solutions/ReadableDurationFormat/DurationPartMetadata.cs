using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.ReadableDurationFormat
{
    public class DurationPartMetadata
    {
        public DurationPartMetadata(string singleForm, string pluralForm, int divisor)
        {
            SingleForm = singleForm;
            PluralForm = pluralForm;
            Divisor = divisor;
        }
        public string SingleForm { get; }
        public string PluralForm { get;}
        public int Divisor { get; }
    }
}
