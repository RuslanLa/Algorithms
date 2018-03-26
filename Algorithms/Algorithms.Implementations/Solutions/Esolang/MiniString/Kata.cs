using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for https://www.codewars.com/kata/586dd26a69b6fd46dd0000c0
/// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
/// There is more suitable for unit-testing class - Interpreter
/// </summary>
public class Kata
{
    public static string MyFirstInterpreter(string code)
    {
        var bytes = MapAggregate(code.Split('.').Select(part => part.Count(character => character == '+'))).ToArray();
        return String.Join("",
            bytes.Take(bytes.Length - 1));
    }
    private static IEnumerable<char> MapAggregate(IEnumerable<int> plusesCount)
    {
        byte cellValue = 0;
        foreach (var count in plusesCount)
        {
            cellValue = (byte)(cellValue + count);
            yield return (char)cellValue;
        }
    }
}