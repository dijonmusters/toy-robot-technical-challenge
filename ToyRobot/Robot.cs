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
            if (_active)
                Console.WriteLine($"{_location.X},{_location.Y},{_direction}");
            else
                Console.WriteLine("Please place the robot first");
        }

        public void Move()
        {
            Console.WriteLine("Moving the robot");
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
    }
}