using NUnit.Framework;
using ToyRobotConsole;

namespace Tests
{
    public class RobotRotateTests
    {
        private Game _game;
        private Robot _robot;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
            _robot = new Robot(_game);
            _robot.Place(0, 0, Direction.NORTH);
        }

        [Test]
        public void ActiveRobotDirection()
        {
            Direction expected = Direction.NORTH;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotDirectionPlaceNorth()
        {
            _robot.Place(0, 0, Direction.NORTH);
            Direction expected = Direction.NORTH;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotDirectionPlaceEast()
        {
            _robot.Place(0, 0, Direction.EAST);
            Direction expected = Direction.EAST;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotDirectionPlaceSouth()
        {
            _robot.Place(0, 0, Direction.SOUTH);
            Direction expected = Direction.SOUTH;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotDirectionPlaceWest()
        {
            _robot.Place(0, 0, Direction.WEST);
            Direction expected = Direction.WEST;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotRotates()
        {
            Direction dirBefore = _robot.Direction;
            _robot.Rotate(Rotation.LEFT);
            Direction dirAfter = _robot.Direction;
            Assert.AreNotEqual(dirBefore, dirAfter, $"{dirBefore} should not be the same as {dirAfter}");
        }

        [Test]
        public void RobotRotatesLeft()
        {
            _robot.Rotate(Rotation.LEFT);
            Direction expected = Direction.WEST;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }

        [Test]
        public void RobotRotatesRight()
        {
            _robot.Rotate(Rotation.RIGHT);
            Direction expected = Direction.EAST;
            Direction actual = _robot.Direction;
            Assert.AreEqual(actual, expected, $"{actual} should be the same as {expected}");
        }
    }
}