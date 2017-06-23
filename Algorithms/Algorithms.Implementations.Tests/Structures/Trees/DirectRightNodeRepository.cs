using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Structures.Trees;

namespace Algorithms.Implementations.Tests.Structures.Trees
{

    /// <summary>
    /// Repository for nodes
    /// </summary>
    internal class DirectRightNodeRepository
    {

        /// <summary>
        /// Returns nodes 
        /// </summary>
        /// <param name="mockNum"></param>
        /// <returns></returns>
        public DirectRightNode<int> GetMock(int mockNum)
        {
            var nodes = Enumerable.Range(0, 11).Select(x => new DirectRightNode<int>(x)).ToList();
            switch (mockNum)
            {
                case 0:
                    nodes[0].Left = nodes[1];
                    nodes[0].Right = nodes[2];
                    nodes[1].Left = nodes[3];
                    nodes[1].Right = nodes[4];
                    nodes[2].Right = nodes[5];
                    nodes[3].Left = nodes[6];
                    nodes[4].Right = nodes[7];
                    nodes[5].Right = nodes[8];
                    nodes[7].Right = nodes[9];
                    nodes[8].Right = nodes[10];
                    break;
                case 1:
                    nodes[0].Left = nodes[1];
                    nodes[1].Left = nodes[2];
                    nodes[2].Left = nodes[3];
                    nodes[3].Left = nodes[4];
                    nodes[4].Left = nodes[5];
                    nodes[5].Left = nodes[6];
                    break;
                case 2:
                    nodes[0].Left = nodes[1];
                    nodes[0].Right = nodes[2];
                    nodes[1].Left = nodes[3];
                    nodes[2].Right = nodes[4];
                    nodes[3].Left = nodes[5];
                    nodes[4].Right = nodes[6];
                    nodes[6].Left = nodes[7];
                    nodes[6].Right = nodes[8];
                    break;
            }

            return nodes[0];

        }

        /// <summary>
        /// Returns direct right matchings
        /// </summary>
        /// <param name="mockNum"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetDirectRightHelper(int mockNum)
        {
            switch (mockNum)
            {
                case 0:
                    return new Dictionary<int, int>()
                    {
                        {1, 2},
                        {3, 4},
                        {4, 5},
                        {6, 7},
                        {7, 8},
                        {9, 10}
                    };
                case 2:
                    return new Dictionary<int, int>()
                    {
                        {1, 2},
                        {3, 4},
                        {5, 6},
                        {7, 8}
                    };
                default:
                    return new Dictionary<int, int>();
            }
        }

        /// <summary>
        /// Returns enumeration result helper 
        /// </summary>
        /// <param name="mockNum"></param>
        /// <returns></returns>
        public List<int> GetEnumeratorHelper(int mockNum)
        {
            switch (mockNum)
            {
                case 0:
                    return new List<int>()
                    {
                        0, 1, 3 , 6, 4, 7, 9, 2, 5, 8, 10
                    };
                case 1:
                    return new List<int>() { 0, 1, 2, 3, 4, 5, 6};
                case 2:
                    return new List<int>() {0, 1, 3, 5, 2, 4, 6, 7, 8};
                default:
                    return new List<int>() {0};
            }

        } 
    }
}
