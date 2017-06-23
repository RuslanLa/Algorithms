using System.Collections.Generic;

namespace Algorithms.Implementations.Structures.Trees
{
    /// <summary>
    /// Base class for the binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseBinaryTreeNode<T>
    {
        protected BaseBinaryTreeNode(T curValue)
        {
            Value = curValue;
        } 
        /// <summary>
        /// Returns subitems
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<BaseBinaryTreeNode<T>> GetSubItems();

        /// <summary>
        /// Current node Value
        /// </summary>
        public T Value { get;  private set; }
         
        /// <summary>
        /// Level of the node
        /// </summary>
        protected uint Level { get; set; }


        /// <summary>
        /// Fill level of the current node and of this child
        /// Level starts from the current node
        /// </summary>
        protected void FillLevels()
        {
            FillLevels(null);
        }

        /// <summary>
        /// Fill levels
        /// </summary>
        /// <param name="parentLevel"></param>
        private void FillLevels(uint? parentLevel)
        {
            Level = parentLevel + 1 ?? 0;
            foreach (var item in GetSubItems())
            {
                item.FillLevels(Level);
            }
        }

        /// <summary>
        /// Returns enumerable
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <returns></returns>
        protected IEnumerable<TU> AsEnumerable<TU>() where  TU: BaseBinaryTreeNode<T>
        {
            yield return (TU)this;
            foreach (var subItem in GetSubItems())
            {
                foreach (var  childs in subItem.AsEnumerable<TU>())
                {
                    yield return childs;
                }
            }
        }
    }
}
