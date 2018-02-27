using System.Collections.Generic;

namespace Algorithms.Implementations.Solutions.MoleculToAtoms
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/molecule-to-atoms/train/csharp
    /// </summary>
    public class MoleculConverter
    {
        public Dictionary<string, int> ToAtom(string molecul)
        {
            var treeBuilder = new AtomTreeBuilder();
            var tree = treeBuilder.Build(molecul);
            return new AtomTreeConverter().ToDictionary(tree);
        }
    }
}
