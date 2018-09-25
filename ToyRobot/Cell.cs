namespace ToyRobotConsole
{
    /// <summary>A Cell is a single location containing an x and y coordinate.</summary>
    public class Cell
    {
        /// <summary>Private field for x coordinate.</summary>
        private int _x;

        /// <summary>Private field y coordinate.</summary>
        private int _y;

        /// <summary>Read-only property for x coordinate.</summary>
        /// <value>Gets the value of x coordinate</value>
        public int X { get { return _x; } }

        /// <summary>Read-only property for y coordinate.</summary>
        /// <value>Gets the value of y coordinate</value>
        public int Y { get { return _y; } }

        /// <summary>Cell constructor</summary>
        /// <param name="x">An int parameter for the Cell's x coordinate</param>
        /// <param name="y">An int parameter for the Cell's y coordinate</param>
        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}