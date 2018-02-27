using System.Linq;

namespace Algorithms.Implementations.Solutions.MoleculToAtoms
{
    public class AtomTree
    {
        private AtomTree(int multiplier, AtomTree[] childs)
        {
            Multiplier = multiplier;
            Childs = childs;
        }

        private AtomTree(string atom)
        {
            Atom = atom;
            Childs = new AtomTree[0];
        }

        public static AtomTree FromAtomName(string atom)
        {
            return new AtomTree(atom);
        }

        public static AtomTree FromMultiplier(int multiplier, AtomTree[] childs)
        {
            return new AtomTree(multiplier, childs);
        }
        public int Multiplier { get; }

        public string Atom { get; }

        public AtomTree[] Childs { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is AtomTree anotherAtom))
            {
                return false;
            }

            return Multiplier.Equals(anotherAtom.Multiplier) &&
                   ((Atom == null && anotherAtom.Atom == null) || Atom != null && Atom.Equals(anotherAtom.Atom))
                   && Childs.Length==anotherAtom.Childs.Length &&
                   Enumerable.Range(0, Childs.Length).All(i => Childs[i].Equals(anotherAtom.Childs[i]));
        }
    }
}
