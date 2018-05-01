using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.TopDownMovement;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.TopDownMovement
{
    public class PlayerMovementTests
    {

        [Fact]
        private void UpdateTest()
        {
            var player = new PlayerMovement(0, 0);
            Input.Press(Direction.Down);
            player.Update();
            player.Direction.ShouldBe(Direction.Down);
            player.Position.ShouldBe(new Tile(0, 0));
            player.Update();
            player.Position.ShouldBe(new Tile(0, -1));
            player.Update();
            player.Position.ShouldBe(new Tile(0, -2));
            Input.Press(Direction.Left);
            Input.Press(Direction.Right);
            player.Update();
            player.Position.ShouldBe(new Tile(0, -2));
            player.Update();
            player.Position.ShouldBe(new Tile(-1, -2));

        }
    }
}
