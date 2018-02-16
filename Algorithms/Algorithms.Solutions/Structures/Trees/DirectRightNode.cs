using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Solutions.Structures.Trees
{
    /// <summary>
    /// Binary Tree node with link to the direct right
    /// Direct right - is the next right node at the same level
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DirectRightNode<T>: BaseBinaryTreeNode<T>
    {

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public DirectRightNode(T value):base(value)
        {
            _subItems = new Pair<DirectRightNode<T>>();
        }
        #endregion

        #region Fields
        /// <summary>
        /// Pair of the child items
        /// </summary>
        private readonly Pair<DirectRightNode<T>> _subItems;
        #endregion

        #region Properties
        /// <summary>
        /// Node that direct right for current
        /// </summary>
        public DirectRightNode<T> DirectRight { get; private set; }

        /// <summary>
        /// Left child node
        /// </summary>
        public DirectRightNode<T> Left
        {
            get { return _subItems.Left; }
            set { _subItems.Left = value; }
        }

        /// <summary>
        /// Right child node
        /// </summary>
        public DirectRightNode<T> Right
        {
            get { return _subItems.Right; }
            set { _subItems.Right = value; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Fill Direct right nodes 
        /// using levels
        /// </summary>
        public void FillDirect()
        {
            FillLevels();
            foreach (var level in AsEnumerable<DirectRightNode<T>>().GroupBy(x=>x.Level).Select(g=>g.ToList()))
            {
                for (var i = 0; i < level.Count-1; i++)
                {
                    level[i].DirectRight = level[i + 1];
                }
            }
        }


        #region BaseBinaryTreeNode imlementation
        /// <summary>
        /// Return subitems
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<BaseBinaryTreeNode<T>> GetSubItems()
        {
            return _subItems;
        }
        #endregion
        #endregion

        public IEnumerable<DirectRightNode<T>> AsEnumerable()
        {
            return AsEnumerable<DirectRightNode<T>>();
        }
    }
}
