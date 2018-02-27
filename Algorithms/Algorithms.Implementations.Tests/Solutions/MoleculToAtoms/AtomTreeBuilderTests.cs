using System.Collections;
using System.Collections.Generic;
using Algorithms.Implementations.Solutions.MoleculToAtoms;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.MoleculToAtoms
{
    public class AtomTreeBuilderTests
    {
        public AtomTreeBuilderTests()
        {
            _atomTreeBuilder = new AtomTreeBuilder();
        }
        private class AtomTreeBuilderTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]
                {
                    "K4[ON(SO3)2]2",
                    AtomTree.FromMultiplier(1,
                        new AtomTree[]
                        {
                            AtomTree.FromMultiplier(2, new AtomTree[]
                            {
                                AtomTree.FromMultiplier(2, new AtomTree[]
                                {
                                    AtomTree.FromMultiplier(3, new AtomTree[]
                                    {
                                        AtomTree.FromAtomName("O"), 
                                    }), 
                                    AtomTree.FromAtomName("S"), 
                                }), 
                                AtomTree.FromAtomName("N"),
                                AtomTree.FromAtomName("O"),                                
                            }),
                            AtomTree.FromMultiplier(4, new AtomTree[]
                            {
                                AtomTree.FromAtomName("K"), 
                            }), 
                        })
                },
                new object[]
                {
                    "Mg(OH)2",
                    AtomTree.FromMultiplier(1,
                        new AtomTree[]
                        {
                            AtomTree.FromMultiplier(2, new AtomTree[]
                            {
                                AtomTree.FromAtomName("H"),
                                AtomTree.FromAtomName("O"), 
                            }),
                            AtomTree.FromAtomName("Mg"), 
                        })
                }
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        private readonly AtomTreeBuilder _atomTreeBuilder;

        [Theory]
        [ClassData(typeof(AtomTreeBuilderTestDataGenerator))]
        public void BuildTree(string input, AtomTree expectedTree)
        {
            var resultTree = _atomTreeBuilder.Build(input);
            resultTree.ShouldBe(expectedTree);
        }
    }
}
