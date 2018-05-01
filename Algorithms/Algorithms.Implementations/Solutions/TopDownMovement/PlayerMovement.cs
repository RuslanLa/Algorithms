using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations.Solutions.TopDownMovement
{
    /// <summary>
    /// Solution for the KATA https://www.codewars.com/kata/59315ad28f0ebeebee000159
    /// </summary>
    public class PlayerMovement
    {
        public Tile Position { get; private set; }
        public Direction Direction { get; private set; }
        private bool _hasDirection { get; set; }
        private Dictionary<Direction, bool> _pressed { get; set; }
        private Stack<List<Direction>> _sequence { get; set; }
        private List<Direction> _directions = new List<Direction>(){Direction.Up, Direction.Down, Direction.Left, Direction.Right};

        public PlayerMovement(int x, int y)
        {
            _pressed = new Dictionary<Direction, bool>();
            _sequence = new Stack<List<Direction>>();
            Position = new Tile(x, y);
        }
        public void Update()
        {
            var pressed = this.GetPressed();
            var newPressed = this.GetNewPressed(pressed);
            var released = this.GetReleased(pressed);
            _pressed = pressed;
            this.HandleReleased(released);
            if (newPressed.Count > 0)
            {
                _sequence.Push(newPressed);
            }

            Position = Go();
        }

        private Tile Go()
        {
            var hasDirectionBefore = _hasDirection;
            _hasDirection = false;
            if (_sequence.Count == 0)
            {
                return Position;
            }
            var lastRound = _sequence.Peek();
            if (lastRound == null)
            {
                return Position;
            }

            _hasDirection = true;
            var currentDirection = _directions.FirstOrDefault(d => lastRound.Contains(d));
            if (currentDirection != Direction || !hasDirectionBefore)
            {
                Direction = currentDirection;
                return Position;
            }
            switch (currentDirection)
            {
                case Direction.Up:
                    return new Tile(Position.X, Position.Y + 1);
                case Direction.Down:
                    return new Tile(Position.X, Position.Y - 1);
                case Direction.Left:
                    return new Tile(Position.X-1, Position.Y );
                default:
                    return new Tile(Position.X + 1, Position.Y);

            }
        }

        private Dictionary<Direction, bool> GetPressed()
        {
            return _directions.ToDictionary(d => d, Input.GetState);
        }

        private List<Direction> GetNewPressed(Dictionary<Direction, bool> pressed)
        {
            return pressed.Where(p => p.Value && (!_pressed.ContainsKey(p.Key)|| !_pressed[p.Key])).Select(p=>p.Key).ToList();
        }

        private List<Direction> GetReleased(Dictionary<Direction, bool> pressed)
        {
            return _pressed.Where(p => p.Value && !pressed[p.Key]).Select(p => p.Key).ToList();
        }

        private void RebuildSequence()
        {
            var newSequence = new Stack<List<Direction>>();
            foreach (var directions in _sequence.Reverse())
            {
                if (directions.Count == 0)
                {
                    continue;
                }
                newSequence.Push(directions);
            }

            _sequence = newSequence;
        }

        private void HandleReleased(List<Direction> released)
        {
            var hasToRemove = false;
            foreach (var direction in released)
            {
                var item = _sequence.FirstOrDefault(d => d.Contains(direction));

                if (item == null)
                {
                    continue;
                }

                item.Remove(direction);

                if (item.Count == 0)
                {
                    hasToRemove = true;
                }
            }

            if (!hasToRemove)
            {
                return;
            }
            RebuildSequence();
        }

    }
}

