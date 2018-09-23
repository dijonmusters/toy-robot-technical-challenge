using NUnit.Framework;
using ToyRobotConsole;

namespace Tests
{
    public class Tests
    {
        private Robot _robot;
        [SetUp]
        public void Setup()
        {
            _robot = new Robot();
        }

        [Test]
        public void TestRobotIsWorking()
        {
            bool actual = _robot.IsWorking();
            Assert.IsTrue(actual, $"{actual} should be true");
        }
    }
}