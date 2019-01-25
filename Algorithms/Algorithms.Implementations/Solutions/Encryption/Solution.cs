using System.IO;
using System;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    class TableSize
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
    /// <summary>
    /// Solution for https://www.hackerrank.com/challenges/encryption/problem
    /// </summary>
    public class Encryptor
    {
        public string Encrypt(string input)
        {
            var withoutTabs = ClearFromSpaces(input);
            var table = CalculateTableSize(withoutTabs.Length);
            return Encrypt(withoutTabs, table);
        }

        private string Encrypt(string clearedInput, TableSize tableSize)
        {
            var encryptedResult = new StringBuilder();
            for (int j = 0; j < tableSize.Columns; j++)
            {
                if (j != 0)
                {
                    encryptedResult.Append(" ");
                }
                for (int i = 0; i < tableSize.Rows; i++)
                {
                    var index = CalculateOrderNum(i, j, tableSize);
                    if (index >= clearedInput.Length)
                    {
                        break;
                    }
                    encryptedResult.Append(clearedInput[index]);
                }
            }

            return encryptedResult.ToString();
        }

        private int CalculateOrderNum(int rowNum, int columnNum, TableSize tableSize)
        {
            return rowNum * tableSize.Columns + columnNum;
        }

        private string ClearFromSpaces(string input)
        {
            return Regex.Replace(input, " ", "");
        }

        private TableSize CalculateTableSize(int length)
        {
            var sqrt = Math.Sqrt(length);
            var rows = (int)sqrt;
            var columns = (int)Math.Ceiling(sqrt);
            var possibleSize = rows * columns;
            if (possibleSize < length)
            {
                rows++;
            }
            return new TableSize() { Rows = rows, Columns = columns };
        }
    }
    // Complete the encryption function below.
    static string encryption(string s)
    {
        return new Encryptor().Encrypt(s);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string s = Console.ReadLine();
        string result = encryption(s);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
