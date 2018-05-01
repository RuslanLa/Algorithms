using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.TopDownMovement
{
    public class Input
    {
        private static Dictionary<Direction, bool> pressedKeys = new Dictionary<Direction, bool>();
        public static bool GetState(Direction direction)
        {
            return pressedKeys.ContainsKey(direction)&&pressedKeys[direction];
        }

        public static void Press(Direction direction)
        {
            if (!pressedKeys.ContainsKey(direction))
            {
                pressedKeys.Add(direction, true);
                return;
            }
            pressedKeys[direction] = true;
        }

        public static void Release(Direction direction)
        {
            pressedKeys[direction] = false;
        }
    }
}
