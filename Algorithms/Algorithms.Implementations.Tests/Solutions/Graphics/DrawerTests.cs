using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Implementations.Solutions.Graphics;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Graphics
{
    public class DrawerTests
    {
        public class CircleTestCasesGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    2, 2, 2, new List<Drawer.Point>()
                    {
                        new Drawer.Point(0 ,2),
                        new Drawer.Point(1, 1),
                        new Drawer.Point(1, 3),
                        new Drawer.Point(3, 1),
                        new Drawer.Point(3, 3),
                        new Drawer.Point(2, 0),
                        new Drawer.Point(2, 4),
                        new Drawer.Point(4, 2)
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [Theory]
        [ClassData(typeof(CircleTestCasesGenerator))]
        public void CircleTest(int x, int y, int r, List<Drawer.Point> expectedPoints)
        {
            var points = Drawer.GetVisiblePartOfCircle(x, y, r).ToArray();
            points.Length.ShouldBe(expectedPoints.Count);
            foreach (var point in points)
            {
                expectedPoints.ShouldContain(point);
            }
        }
    }
}
