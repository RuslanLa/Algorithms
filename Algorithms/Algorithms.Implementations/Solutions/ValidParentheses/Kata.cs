using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/52774a314c2333f0a7000688
/// </summary>
public class Parentheses
{
    public static bool ValidParentheses(string input)
    {
        var stack = new Stack<bool>();
        foreach (var isOpening in input.Select(c=>c == '('))
        {
            if (isOpening)
            {
                stack.Push(true);
                continue;
            }

            if (stack.Count == 0)
            {
                return false;
            }

            stack.Pop();

        }

        return stack.Count == 0;
    }
}