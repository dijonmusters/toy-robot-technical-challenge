namespace ToyRobotConsole
{
    public class Cell
    {
        private int _x, _y;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}