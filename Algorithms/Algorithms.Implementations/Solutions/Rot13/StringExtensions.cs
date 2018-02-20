using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.Rot13
{
    public static class StringExtensions
    {
        public static string ToRot13(this string message)
        {
              return Rot13Converter.Convert(message);
        }
        
        private class Rot13Converter
        {
            public static string Convert(string message)
            {
                return new string(message.Select(c => Convert(c)).ToArray());
            }

            private static char Convert(char character)
            {
                char result;
                if (TryConvertChar(character, 'a', 'z', out result))
                {
                    return result;
                }

                if (TryConvertChar(character, 'A', 'Z', out result))
                {
                    return result;
                }

                return character;
            }

            private static bool TryConvertChar(char character, char from, char to, out char result)
            {
                if (character < from || character > to)
                {
                    result = Char.MinValue;
                    return false;
                }

                var distance = character - from;
                if (distance < 13)
                {
                    result = (char) (from + 13 + distance);
                    return true;
                }

                result = (char)(from + distance - 13);
                return true;
            }
        }
    }
}
