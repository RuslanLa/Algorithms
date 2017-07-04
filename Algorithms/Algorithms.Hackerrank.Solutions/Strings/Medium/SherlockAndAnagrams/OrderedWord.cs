using System;
using System.Linq;

namespace Algorithms.Hackerrank.Solutions.Strings.Medium.SherlockAndAnagrams
{
    public class OrderedWord
    {
        private string _curValue { get; set; }

        public OrderedWord()
        {
            _curValue = String.Empty;
        }

        public string AddLetter(char letter)
        {
            var code = (int)letter;
            var prevPosition= _curValue.Select((v, i) => new { v, i }).FirstOrDefault(x => (int)x.v > code);
            if (prevPosition == null)
            {
                _curValue+= letter;
            }
            else
            {
                var postfix = _curValue.Substring(prevPosition.i, _curValue.Length - prevPosition.i);
                var prefix = prevPosition.i == 0 ? String.Empty : _curValue.Substring(0, prevPosition.i);
                _curValue = prefix + letter + postfix;
            }
            return _curValue;
        }
    }
}
