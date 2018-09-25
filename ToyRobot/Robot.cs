using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public enum Direction { NORTH, EAST, SOUTH, WEST }
    public class Robot
    {
        private enum Warning { INACTIVE, BOUNDARY, PLACE }
        List<Cell> _map;
        Cell _location;
        Direction _direction;
        bool _active;

        public Robot(List<Cell> map)
        {
            _map = map;
            _active = false;
        }

        public void Place(int x, int y, Direction direction)
        {
            Cell location = _map.Find(c => c.X == x && c.Y == y);

            if (location != null)
            {
                _location = location;
                _direction = direction;
                Activate();
            }
            else
                PrintWarning(Warning.PLACE);
        }

        public void Report()
        {
            if (IsReady())
                Console.WriteLine($"{_location.X},{_location.Y},{_direction}");
            else
                PrintWarning(Warning.INACTIVE);
        }

        public void Move()
        {
            if (!IsReady())
                PrintWarning(Warning.INACTIVE);
            else
            {
                switch (_direction)
                {
                    case Direction.NORTH:
                        MoveNorth();
                        break;
                    case Direction.SOUTH:
                        MoveSouth();
                        break;
                    case Direction.EAST:
                        MoveEast();
                        break;
                    case Direction.WEST:
                        MoveWest();
                        break;
                }
            }
        }

        public void Left()
        {
            if (IsReady())
            {
                Direction last = (Direction) Enum.GetValues(typeof(Direction)).Length - 1;
                _direction--;
                if (_direction < 0)
                    _direction = last;
            }
            else
                PrintWarning(Warning.INACTIVE);
        }

        public void Right()
        {
            if (IsReady())
            {
                Direction last = (Direction) Enum.GetValues(typeof(Direction)).Length - 1;
                _direction++;
                if (_direction > last)
                    _direction = 0;
            }
            else
                PrintWarning(Warning.INACTIVE);
        }

        private void Activate()
        {
            _active = true;
        }

        private bool IsReady()
        {
            return _active;
        }

        private void MoveNorth()
        {
            Cell location = _map.Find(c => c.X == _location.X && c.Y == _location.Y + 1);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }
        private void MoveSouth()
        {
            Cell location = _map.Find(c => c.X == _location.X && c.Y == _location.Y - 1);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }
        private void MoveEast()
        {
            Cell location = _map.Find(c => c.X == _location.X + 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }
        private void MoveWest()
        {
            Cell location = _map.Find(c => c.X == _location.X - 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }

        private void PrintWarning(Warning warning)
        {
            switch(warning)
            {
                case Warning.INACTIVE:
                    Console.WriteLine("Invalid command! Please place the robot somewhere first.");
                    break;
                case Warning.BOUNDARY:
                    Console.WriteLine("Whoa! Careful! You nearly fell off!");
                    break;
                case Warning.PLACE:
                    Console.WriteLine("Don't be silly! We can't place the robot there!");
                    break;
            }
        }
    }
}