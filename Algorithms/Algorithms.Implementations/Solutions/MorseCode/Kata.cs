//using System;
//using System.Linq;

/// <summary>
/// Solution for the KATA https://www.codewars.com/kata/decode-the-morse-code
/// </summary>
//class MorseCodeDecoder
//{
//    public static string Decode(string morseCode)
//    {
//        return String.Join(" ", morseCode.Split(new[] { "   " }, StringSplitOptions.None)
//            .Where(w => !String.IsNullOrEmpty(w))
//            .Select(w => String.Join("", w.Split(' ').Where(c => !String.IsNullOrEmpty(c)).Select(MorseCode.Get))));
//    }
//}