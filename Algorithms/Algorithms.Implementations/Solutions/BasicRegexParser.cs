namespace Algorithms.Implementations.Solutions
{
    /// <summary>
    /// https://www.pramp.com/question/KvZ3aL35Ezc5K9Eq9Llp
    /// Implement a regular expression function isMatch that supports the '.' and '*' symbols.
    ///  The function receives two strings - text and pattern - and should return true if the text
    ///  matches the pattern as a regular expression. For simplicity, assume that the actual symbols '.' 
    /// and '*' do not appear in the text string and are used as special symbols only in the pattern string.
    /// </summary>
    public class BasicRegexParser
    {
        public bool IsMatch(string text, string pattern)
        {
            return IsMatch(text, pattern, 0, 0);
        }

        private bool IsEndOfTheText(string text, int textIndex) => textIndex >= text.Length;
        private bool IsAsteriskAfterCurrent(string text, int textIndex) => textIndex < text.Length - 1 && text[textIndex+1] == '*';
        private bool IsPoint(string pattern, int patternIndex) => pattern[patternIndex] == '.';
        private bool IsMatch(string text, string pattern, int textIndex, int patternIndex)
        {
            var isEndOfTheText = IsEndOfTheText(text, textIndex);
            var isEndOfThePattern = IsEndOfTheText(pattern, patternIndex);
            var isAsteriskAfterCurrent = IsAsteriskAfterCurrent(pattern, patternIndex);
            if (isEndOfThePattern && isEndOfTheText)
            {
                return true;
            }

            if(isEndOfTheText)
            {
                if (IsAsteriskAfterCurrent(pattern, patternIndex))
                {
                    if (patternIndex + 2 == pattern.Length)
                    {
                        return true;
                    }

                    if (IsPoint(pattern, patternIndex))
                    {
                        return IsMatch(text, pattern, textIndex, patternIndex + 2);
                    }
                }
            }

            if (isEndOfTheText || isEndOfThePattern)
            {
                return false;
            }

            if (text[textIndex] == pattern[patternIndex] || IsPoint(pattern, patternIndex))
            {
                if (isAsteriskAfterCurrent)
                {
                    return IsMatch(text, pattern, textIndex + 1, patternIndex);
                }
                return IsMatch(text, pattern, textIndex + 1, patternIndex + 1);
            }

            if (isAsteriskAfterCurrent)
            {
                return IsMatch(text, pattern, textIndex, patternIndex + 2);
            }

            return false;
        }
    }
}
