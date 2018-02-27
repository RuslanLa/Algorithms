//using System;
//using System.Collections.Generic;

///// <summary>
///// Solution for https://www.codewars.com/kata/52f831fa9d332c6591000511/csharp
///// All code is located in one file cause it is more convinient to copy-past it to codewars solution's window
///// There is more suitable for unit-testing class - MoleculConverter
///// </summary>
//public class Kata
//{
//    public static Dictionary<string, int> ParseMolecule(string formula)
//    {
//        return new MoleculConverter().ToAtom(formula);
//    }

//    private class MoleculConverter
//    {
//        public Dictionary<string, int> ToAtom(string molecul)
//        {
//            var treeBuilder = new AtomTreeBuilder();
//            var tree = treeBuilder.Build(molecul);
//            return new AtomTreeConverter().ToDictionary(tree);
//        }
//    }

//    private class AtomTreeConverter
//    {
//        public Dictionary<string, int> ToDictionary(AtomTree tree)
//        {
//            var result = new Dictionary<string, int>();
//            return FillDictionary(tree, 1, result);
//        }


//        private Dictionary<string, int> FillDictionary(AtomTree tree, int multiplier, Dictionary<string, int> dictionary)
//        {
//            if (!String.IsNullOrEmpty(tree.Atom))
//            {
//                if (dictionary.ContainsKey(tree.Atom))
//                {
//                    dictionary[tree.Atom] += multiplier;
//                    return dictionary;
//                }

//                dictionary.Add(tree.Atom, multiplier);
//                return dictionary;
//            }

//            multiplier *= tree.Multiplier;

//            foreach (var child in tree.Childs)
//            {
//                FillDictionary(child, multiplier, dictionary);
//            }

//            return dictionary;
//        }
//    }

//    private class AtomTree
//    {
//        private AtomTree(int multiplier, AtomTree[] childs)
//        {
//            Multiplier = multiplier;
//            Childs = childs;
//        }

//        private AtomTree(string atom)
//        {
//            Atom = atom;
//            Childs = new AtomTree[0];
//        }

//        public static AtomTree FromAtomName(string atom)
//        {
//            return new AtomTree(atom);
//        }

//        public static AtomTree FromMultiplier(int multiplier, AtomTree[] childs)
//        {
//            return new AtomTree(multiplier, childs);
//        }

//        public int Multiplier { get; }

//        public string Atom { get; }

//        public AtomTree[] Childs { get; }
//    }

//    private class AtomTreeBuilder
//    {
//        public AtomTree Build(string molecul)
//        {
//            var moleculChars = molecul.ToCharArray();
//            var oppeningBracketsPositions = GetOpenningsBracketsPositions(moleculChars);
//            return AtomTree.FromMultiplier(1,
//                GetChilds(moleculChars, 0, molecul.Length - 1, oppeningBracketsPositions));
//        }

//        private bool IsOpenningBracket(char input) => input == '{' || input == '['
//                                                                   || input == '(';

//        private bool IsClosingBracket(char input) => input == '}' || input == ']'
//                                                                  || input == ')';

//        private char GetOpenningBracket(char closingBracket)
//        {
//            switch (closingBracket)
//            {
//                case '}':
//                    return '{';
//                case ')':
//                    return '(';
//                case ']':
//                    return '[';
//                default:
//                    throw new InvalidOperationException($"Unexpected char {closingBracket} in GetOpenningBracket");
//            }
//        }

//        private Dictionary<int, int> GetOpenningsBracketsPositions(char[] molecul)
//        {
//            var result = new Dictionary<int, int>();
//            var braces = new Dictionary<char, Stack<int>>();
//            for (int i = 0; i < molecul.Length; i++)
//            {
//                var isOpenning = IsOpenningBracket(molecul[i]);
//                var isClosing = IsClosingBracket(molecul[i]);
//                if (!isOpenning && !isClosing)
//                {
//                    continue;
//                }

//                if (isOpenning)
//                {
//                    if (!braces.ContainsKey(molecul[i]))
//                    {
//                        braces[molecul[i]] = new Stack<int>();
//                    }

//                    braces[molecul[i]].Push(i);
//                    continue;
//                }

//                var openning = GetOpenningBracket(molecul[i]);
//                if (!braces.ContainsKey(openning) || braces[openning].Count == 0)
//                {
//                    continue;
//                }

//                var openningIndex = braces[openning].Pop();
//                result.Add(i, openningIndex);
//            }

//            return result;
//        }

//        private AtomTree GetAtomTree(char[] chars, ref int current, int? multiplier)
//        {
//            var atomName = GetAtomName(chars, ref current);
//            var atomTree = AtomTree.FromAtomName(atomName);
//            return multiplier.HasValue
//                ? AtomTree.FromMultiplier(multiplier.Value, new[] { atomTree })
//                : atomTree;
//        }

//        private int GetMultiplier(char[] chars, ref int index)
//        {
//            int multiplier = 0;
//            int rank = 1;
//            while (index >= 0 && Char.IsDigit(chars[index]))
//            {
//                multiplier = (int)Char.GetNumericValue(chars[index]) * rank + multiplier;
//                rank *= 10;
//                index--;
//            }

//            return multiplier;
//        }

//        private string GetAtomName(char[] chars, ref int index)
//        {
//            if (Char.IsUpper(chars[index]))
//            {
//                index--;
//                return chars[index + 1].ToString();
//            }

//            var length = 1;
//            while (Char.IsLower(chars[index]) && index > 0)
//            {
//                length++;
//                index--;
//            }

//            if (index < 0 || !Char.IsUpper(chars[index]))
//            {
//                throw new InvalidOperationException("Invalid molecul form. Cannot find uppercase letter");
//            }

//            index--;
//            return new string(chars, index + 1, length);
//        }

//        private AtomTree[] GetChilds(char[] chars, int from, int to, Dictionary<int, int> openningBracketsPositions)
//        {
//            var current = to;
//            int? multiplier = null;
//            var childs = new List<AtomTree>();
//            while (current >= from)
//            {
//                if (Char.IsDigit(chars[current]))
//                {
//                    multiplier = GetMultiplier(chars, ref current);
//                    continue;
//                }

//                var currentMultiplierValue = multiplier;
//                multiplier = null;

//                if (openningBracketsPositions.ContainsKey(current))
//                {
//                    var openningBracketIndex = openningBracketsPositions[current];
//                    var child = AtomTree.FromMultiplier(currentMultiplierValue ?? 1,
//                        GetChilds(chars, openningBracketIndex + 1, current - 1,
//                            openningBracketsPositions));
//                    current = openningBracketIndex - 1;
//                    childs.Add(child);
//                    continue;
//                }

//                if (Char.IsLetter(chars[current]))
//                {
//                    childs.Add(GetAtomTree(chars, ref current, currentMultiplierValue));
//                    continue;
//                }

//                current--;
//            }

//            return childs.ToArray();
//        }
//    }
//}