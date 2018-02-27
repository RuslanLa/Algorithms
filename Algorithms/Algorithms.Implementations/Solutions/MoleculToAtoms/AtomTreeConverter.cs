using System;
using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions.MoleculToAtoms
{
    public class AtomTreeConverter
    {
        public Dictionary<string, int> ToDictionary(AtomTree tree)
        {
           var result = new Dictionary<string, int>();
            return FillDictionary(tree, 1, result);
        }


        private Dictionary<string, int> FillDictionary(AtomTree tree, int multiplier, Dictionary<string, int> dictionary)
        {
            if (!String.IsNullOrEmpty(tree.Atom))
            {
                if (dictionary.ContainsKey(tree.Atom))
                {
                    dictionary[tree.Atom] += multiplier;
                    return dictionary;
                }

                dictionary.Add(tree.Atom, multiplier);
                return dictionary;
            }

            multiplier *= tree.Multiplier;

            foreach (var child in tree.Childs)
            {
                FillDictionary(child, multiplier, dictionary);
            }

            return dictionary;
        }
    }
}
