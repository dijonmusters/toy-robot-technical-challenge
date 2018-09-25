using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    /// <summary>The Direction enum contains a list of valid robot directions.</summary>
    public enum Direction
    {
        /// <summary>Facing north direction.</summary>
        NORTH,
        /// <summary>Facing east direction.</summary>
        EAST,
        /// <summary>Facing south direction.</summary>
        SOUTH,
        /// <summary>Facing west direction.</summary>
        WEST
    }

    /// <summary>The Robot class contains the functionality for the game's robot.</summary>
    public class Robot
    {
        /// <summary>The Warning enum contains a list of known warning messages.</summary>
        private enum Warning
        {
            /// <summary>The robot is inactive.</summary>
            INACTIVE,
            /// <summary>The requested location is outside the boundary.</summary>
            BOUNDARY,
            /// <summary>The requested location or direction does not exist.</summary>
            PLACE
        }

        /// <summary>Private field for game reference.</summary>
        private Game _game;

        /// <summary>Private field for robot's current location.</summary>
        private Cell _location;

        /// <summary>Public read-only property to expose the robot's location.</summary>
        /// <value>Gets the value of the robot's location</value>
        public Cell Location { get { return _location; } }

        /// <summary>Private field for robot's current direction.</summary>
        private Direction _direction;

        /// <summary>Public read-only property to expose the robot's direction.</summary>
        /// <value>Gets the value of the robot's direction</value>
        public Direction Direction { get { return _direction; } }

        /// <summary>Private field for robot's active status.</summary>
        private bool _active;

        /// <summary>Robot constructor.</summary>
        /// <param name="game">A Game parameter to access game map and ui</param>
        public Robot(Game game)
        {
            _game = game;
            _active = false;
            _direction = (Direction) -1;
        }

        /// <summary>Places the robot in a location on the map and sets the direction.</summary>
        /// <param name="x">An int parameter that represents an x coordinate</param>
        /// <param name="y">An int parameter that represents a y coordinate</param>
        /// <param name="direction">A Direction parameter to represent robot's direction</param>
        public void Place(int x, int y, Direction direction)
        {
            Direction last = (Direction) Enum.GetValues(typeof(Direction)).Length - 1;
            bool directionIsValid = direction >= 0 && direction <= last;
            Cell location = _game.Map.Find(c => c.X == x && c.Y == y);

            if (location != null && directionIsValid)
            {
                _location = location;
                _direction = direction;
                Activate();
            }
            else
                PrintWarning(Warning.PLACE);
        }

        /// <summary>Prints out the robot's current location and direction.</summary>
        public void Report()
        {
            if (IsReady())
                _game.UI.PrintMessage($"{_location.X},{_location.Y},{_direction}");
            else
                PrintWarning(Warning.INACTIVE);
        }

        /// <summary>Calculates which way the robot needs to move.</summary>
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

        /// <summary>Rotates the robot to the left</summary>
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

        /// <summary>Rotates the robot to the right</summary>
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

        /// <summary>Activates the robot so it can process commands</summary>
        private void Activate()
        {
            _active = true;
        }

        /// <summary>Checks if the robot is ready</summary>
        /// <returns>A boolean value representing the active status of the robot</returns>
        public bool IsReady()
        {
            return _active;
        }

        /// <summary>Checks if the robot is located at a specific cell</summary>
        /// <param name="location">A Location parameter that represents coordinates</param>
        /// <returns>A boolean value representing whether the robot is located at cell</returns>
        public bool IsLocated(Cell location)
        {
            return _location == location;
        }

        /// <summary>Moves the robot one cell north</summary>
        private void MoveNorth()
        {
            Cell location = _game.Map.Find(c => c.X == _location.X && c.Y == _location.Y + 1);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }

        /// <summary>Moves the robot one cell east</summary>
        private void MoveEast()
        {
            Cell location = _game.Map.Find(c => c.X == _location.X + 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }

        /// <summary>Moves the robot one cell south</summary>
        private void MoveSouth()
        {
            Cell location = _game.Map.Find(c => c.X == _location.X && c.Y == _location.Y - 1);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }

        /// <summary>Moves the robot one cell west</summary>
        private void MoveWest()
        {
            Cell location = _game.Map.Find(c => c.X == _location.X - 1 && c.Y == _location.Y);
            if (location != null)
                _location = location;
            else
                PrintWarning(Warning.BOUNDARY);
        }

        /// <summary>Prints a known warning to the console</summary>
        /// <param name="warning">
        /// A Warning parameter for the type of warning to be displayed
        /// </param>
        private void PrintWarning(Warning warning)
        {
            switch(warning)
            {
                case Warning.INACTIVE:
                    _game.UI.PrintMessage("Invalid command! Please place the robot somewhere first.");
                    break;
                case Warning.BOUNDARY:
                    _game.UI.PrintMessage("Whoa! Careful! You nearly fell off!");
                    break;
                case Warning.PLACE:
                    _game.UI.PrintMessage("Don't be silly! We can't place the robot there!");
                    break;
            }
        }
    }
}