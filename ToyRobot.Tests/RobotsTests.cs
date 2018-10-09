using NUnit.Framework;
using ToyRobotConsole;

namespace Tests
{
    public class RobotsTests
    {
        private Game _game;
        private Robot _robot;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void UnselectedRobotIgnores()
        {
            _game.CommandProcessor.Execute("Place 0, 0, north");
            _game.CommandProcessor.Execute("move");
            _game.CommandProcessor.Execute("move");
            _game.CommandProcessor.Execute("move");

            _game.Select(0);
            Cell location = _game.Robot.Location;
            Assert.IsNull(location, $"{location} should be null");

            _game.Select(1);
            location = _game.Robot.Location;
            Assert.IsNull(location, $"{location} should be null");
        }

        [Test]
        public void SelectedRobotIgnores()
        {
            _game.Select(0);
            _game.CommandProcessor.Execute("Place 0, 0, north");
            _game.CommandProcessor.Execute("move");
            _game.CommandProcessor.Execute("move");
            _game.CommandProcessor.Execute("move");
            bool expected = true;
            bool actual = _game.Robot.Location.X == 0 && _game.Robot.Location.Y == 3;
            Assert.AreEqual(expected, actual, $"{actual} should be {expected}");
        }
    }
}