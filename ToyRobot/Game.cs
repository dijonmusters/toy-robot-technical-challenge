using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    /// <summary>The Game class manages the game world.</summary>
    public class Game
    {
        /// <summary>Public read-only property to expose the game's map.</summary>
        /// <value>Gets the value of the game's map</value>
        public List<Cell> Map { get; }

        /// <summary>Public read-only property to expose the robot.</summary>
        /// <value>Gets the value of the game's robot</value>
        public Robot Robot { get; }

        /// <summary>Private field for the game's playing state.</summary>
        private bool _playing;

        /// <summary>Private field for the game's GUI state.</summary>
        private bool _gui;

        /// <summary>Private field for the game's command processor.</summary>
        private CommandProcessor _commandProcessor;

        /// <summary>Public read-only property to expose the user interface.</summary>
        /// <value>Gets the value of the game's user interface</value>
        public UserInterface UI { get; }

        /// <summary>Game constructor</summary>
        /// <param name="dim_x">An int parameter for the width of the map</param>
        /// <param name="dim_y">An int parameter for the height of the map</param>
        public Game(int dim_x, int dim_y)
        {
            Map = new List<Cell>();
            for (int y = dim_y - 1; y >= 0; y--)
            {
                for (int x = 0; x < dim_x; x++)
                {
                    Map.Add(new Cell(x, y));
                }
            }
            Robot = new Robot(this);
            _commandProcessor = new CommandProcessor(this);
            UI = new UserInterface(this);
            _gui = false;
        }

        /// <summary>
        /// Game default constructor
        /// Calls overloaded constructor and passes in default dimensions (5x5)
        /// </summary>
        public Game() : this(5, 5)
        {}

        /// <summary>Begins the game and manages the game loop</summary>
        public void Start()
        {
            UI.PrintMessage("Welcome to the Toy Robot simulator!");
            string input = UI.AskUser("Would you like a GUI? ").ToUpper();
            _gui = input == "Y" || input == "YES" || input == "T" || input == "TRUE";
            _playing = true;
            while (_playing)
            {
                if (_gui)
                    UI.PrintGrid();
                string command = UI.AskUser("What would you like to do? ");
                _commandProcessor.Execute(command);
            }
            UI.PrintMessage("Thanks for playing!");
        }

        /// <summary>Ends the game</summary>
        public void Stop()
        {
            _playing = false;
        }
    }
}