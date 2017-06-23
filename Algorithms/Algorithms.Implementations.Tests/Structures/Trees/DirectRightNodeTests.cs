using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Structures.Trees
{
    /// <summary>
    /// Tests for Direct right nodes
    /// </summary>
    public class DirectRightNodeTests
    {
        /// <summary>
        /// Repository for nodes
        /// </summary>
        private readonly DirectRightNodeRepository _repository;

        public DirectRightNodeTests()
        {
            _repository=new DirectRightNodeRepository();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100000)]
        public void TestDirectRightFilling(int mockNum)
        {
            var node = _repository.GetMock(mockNum);
            var helper = _repository.GetDirectRightHelper(mockNum);
            node.FillDirect();
            foreach (var item in node.AsEnumerable())
            {
                if (!helper.ContainsKey(item.Value))
                {
                    var msg = item.DirectRight != null
                        ? $"Direct right of the node {item.Value} should be null, but was {item.DirectRight.Value}"
                        : String.Empty;
                    item.DirectRight.ShouldBeNull(msg);
                    continue;
                }

                var directValue = helper[item.Value];
                item.DirectRight.ShouldNotBeNull(
                   $"Direct right of the node {item.Value} should not be null");
                item.DirectRight.Value.ShouldBe(directValue,
                    $"Direct right of the node {item.Value} should be {directValue} but was {item.DirectRight.Value}");

            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10000)]
        public void TestEnumerator(int mockNum)
        {
            var node = _repository.GetMock(mockNum);
            var helper = _repository.GetEnumeratorHelper(mockNum);
            var enumerable = node.AsEnumerable().ToList().Select(x=>x.Value);
            enumerable.ShouldBe(helper);
        }
    }
}
