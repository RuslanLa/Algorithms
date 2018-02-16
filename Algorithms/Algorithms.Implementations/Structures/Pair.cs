using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Solutions.Structures
{
    /// <summary>
    /// Pair of the items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Pair<T>:IEnumerable<T>
    {
        /// <summary>
        /// Left Item
        /// </summary>
        public T Left { get; set; }
        
        /// <summary>
        /// Right item
        /// </summary>
        public T Right { get; set; }

        #region IEnumerable implementation
        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
            {
                yield return Left;
            }
            if (Right != null)
            {
                yield return Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
