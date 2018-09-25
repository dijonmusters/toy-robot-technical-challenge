using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public enum Direction { NORTH, EAST, SOUTH, WEST }
    public class Robot
    {
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

            if (location == null)
            {
                Console.WriteLine("Don't be silly! We can't place the robot there!");
            }
            else
            {
                _location = location;
                _direction = direction;
                Activate();
            }
        }

        public void Report()
        {
            if (IsReady())
                Console.WriteLine($"{_location.X},{_location.Y},{_direction}");
            else
                Console.WriteLine("Please place the robot first");
        }

        public void Move()
        {
            if (!IsReady())
                Console.WriteLine("Please place the robot first");
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
            Console.WriteLine("Turning robot left");
        }

        public void Right()
        {
            Console.WriteLine("Turning robot right");
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
                PrintWarning();
        }
        private void MoveSouth()
        {
            Cell location = _map.Find(c => c.X == _location.X && c.Y == _location.Y - 1);
            if (location != null)
                _location = location;
            else
                PrintWarning();
        }
        private void MoveEast()
        {
            Cell location = _map.Find(c => c.X == _location.X + 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning();
        }
        private void MoveWest()
        {
            Cell location = _map.Find(c => c.X == _location.X - 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning();
        }

        private void PrintWarning()
        {
            Console.WriteLine("Whoa! Careful! You nearly fell off!");
        }
    }
}