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
        public Robot(List<Cell> map)
        {
            _map = map;
            _location = _map[0];
            _direction = Direction.NORTH;
        }

        public void Report()
        {
            Console.WriteLine($"{_location.X},{_location.Y},{_direction}");
        }
    }
}