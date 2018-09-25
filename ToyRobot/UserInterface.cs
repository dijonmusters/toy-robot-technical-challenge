using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public class UserInterface
    {
        Game _game;

        public UserInterface(Game game)
        {
            _game = game;
        }

        private string CellSymbol(Cell c)
        {
            string grid = " ";
            if (_game.Robot.IsLocated(c))
                grid += "@";
            else
                grid += " ";
            return grid;
        }

        private string GridBorder()
        {
            int width = _game.Map[_game.Map.Count - 1].X + 1;
            string border = " -";
            for (int i = 0; i < width; i++)
            {
                border += "--";
            }
            return border;
        }

        private string BuildGrid()
        {
            string grid = "";
            Cell first = _game.Map[0];
            Cell last = _game.Map[_game.Map.Count - 1];
            foreach (Cell c in _game.Map)
            {
                if (c.X == first.X)
                    grid += "|";
                grid += CellSymbol(c);
                if (c.X == last.X)
                    grid += " |\n";
            }
            return grid;
        }

        public void PrintGrid()
        {
            string grid = GridBorder();
            grid += "\n";
            grid += BuildGrid();
            grid += GridBorder();
            Console.WriteLine(grid);
        }
    }
}