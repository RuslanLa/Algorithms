using System;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/rot13-1/csharp
/// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
/// There is more suitable for unit-testing class - DurationConverter
/// </summary>
public class Kata
{
    public static string Rot13(string message)
    {
        return ToRot13(message);
    }

    public static string ToRot13(string message)
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

            result = (char) (from + distance - 13);
            return true;
        }
    }
}