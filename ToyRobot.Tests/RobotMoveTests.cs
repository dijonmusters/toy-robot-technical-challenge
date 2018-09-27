using NUnit.Framework;
using ToyRobotConsole;

namespace Tests
{
    public class RobotMoveTests
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
        public void RobotMoves()
        {
            Cell locBefore = _robot.Location;
            _robot.Move();
            Cell locAfter = _robot.Location;
            Assert.AreNotEqual(locBefore, locAfter, $"{locBefore} should not be the same as {locAfter}");
        }

        [Test]
        public void RobotMovesNorth()
        {
            _robot.Move();
            int expectedX = 0;
            int expectedY = 1;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotMovesEast()
        {
            _robot.Rotate(Rotation.RIGHT);
            _robot.Move();
            int expectedX = 1;
            int expectedY = 0;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotMovesSouth()
        {
            _robot.Place(2, 2, Direction.SOUTH);
            _robot.Move();
            int expectedX = 2;
            int expectedY = 1;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotMovesWest()
        {
            _robot.Place(2,2,Direction.WEST);
            _robot.Move();
            int expectedX = 1;
            int expectedY = 2;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotRemainsInBoundaryNorth()
        {
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            int expectedX = 0;
            int expectedY = 4;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
            _robot.Move();
            actualX = _robot.Location.X;
            actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotRemainsInBoundaryEast()
        {
            _robot.Place(0, 0, Direction.EAST);
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            int expectedX = 4;
            int expectedY = 0;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
            _robot.Move();
            actualX = _robot.Location.X;
            actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotRemainsInBoundarySouth()
        {
            _robot.Place(0, 4, Direction.SOUTH);
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            int expectedX = 0;
            int expectedY = 0;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
            _robot.Move();
            actualX = _robot.Location.X;
            actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotRemainsInBoundaryWest()
        {
            _robot.Place(4, 0, Direction.WEST);
            _robot.Move();
            _robot.Move();
            _robot.Move();
            _robot.Move();
            int expectedX = 0;
            int expectedY = 0;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
            _robot.Move();
            actualX = _robot.Location.X;
            actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }

        [Test]
        public void RobotRemainsInBoundaryExtreme()
        {
            for (int i = 0; i < 100; i++)
            {
                _robot.Move();
            }
            int expectedX = 0;
            int expectedY = 4;
            int actualX = _robot.Location.X;
            int actualY = _robot.Location.Y;
            Assert.AreEqual(expectedX, actualX, $"{expectedX} should be the same as {actualX}");
            Assert.AreEqual(expectedY, actualY, $"{expectedY} should be the same as {actualY}");
        }
    }
}