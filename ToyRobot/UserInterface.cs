using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    /// <summary>The User Interface is responsible for all interactions with the user.</summary>
    public class UserInterface
    {
        /// <summary>Private field for game.</summary>
        Game _game;

        /// <summary>User Interface constructor</summary>
        /// <param name="game">A game parameter to access game elements</param>
        public UserInterface(Game game)
        {
            _game = game;
        }

        /// <summary>Determines which character should be rendered from cell</summary>
        /// <param name="cell">A cell parameter to determine which symbol is required</param>
        /// <returns>A string value containing the cell's symbol</returns>
        private string CellSymbol(Cell cell)
        {
            string grid = " ";
            if (_game.Robot.IsLocated(cell))
                grid += "@";
            else
                grid += " ";
            return grid;
        }

        /// <summary>Calculates the number of dash characters required for grid border</summary>
        /// <returns>A string value containing the border characters</returns>
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

        /// <summary>Calculates the entire grid world</summary>
        /// <returns>A string value containing the entire grid</returns>
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

        /// <summary>Prints the grid to the console</summary>
        public void PrintGrid()
        {
            string grid = GridBorder();
            grid += "\n";
            grid += BuildGrid();
            grid += GridBorder();
            Console.WriteLine(grid);
        }

        /// <summary>Asks the user a question and returns their response</summary>
        /// <param name="question">A string parameter containing the question for the user</param>
        /// <returns>A string value containing the user's response</returns>
        public string AskUser(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        /// <summary>Prints a message to the console with a consistent format</summary>
        /// <param name="message">A string parameter containing the message to be printed to console</param>
        public void PrintMessage(string message)
        {
            string formattedMessage = message.Replace("\n", "\n# ");
            Console.WriteLine("\n###########");
            Console.WriteLine($"# {formattedMessage}");
            Console.WriteLine("###########\n");
        }
    }
}