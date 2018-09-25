using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    /// <summary>The Game class manages the game world.</summary>
    public class Game
    {
        /// <summary>
        /// Private field for the list of Cells that make up the game map.
        /// </summary>
        private List<Cell> _map;

        /// <summary>Public read-only property to expose the game's map.</summary>
        /// <value>Gets the value of the game's map</value>
        public List<Cell> Map { get { return _map; } }

        /// <summary>Private field for the game's robot.</summary>
        private Robot _robot;

        /// <summary>Public read-only property to expose the robot.</summary>
        /// <value>Gets the value of the game's robot</value>
        public Robot Robot { get { return _robot; } }

        /// <summary>Private field for the game's playing state.</summary>
        private bool _playing;

        /// <summary>Private field for the game's GUI state.</summary>
        private bool _gui;

        /// <summary>Private field for the game's command processor.</summary>
        private CommandProcessor _commandProcessor;

        /// <summary>Private field for the game's user interface.</summary>
        private UserInterface _ui;

        /// <summary>Public read-only property to expose the user interface.</summary>
        /// <value>Gets the value of the game's user interface</value>
        public UserInterface UI { get { return _ui; } }

        /// <summary>Game constructor</summary>
        /// <param name="dim_x">An int parameter for the width of the map</param>
        /// <param name="dim_y">An int parameter for the height of the map</param>
        public Game(int dim_x, int dim_y)
        {
            _map = new List<Cell>();
            for (int y = dim_y - 1; y >= 0; y--)
            {
                for (int x = 0; x < dim_x; x++)
                {
                    _map.Add(new Cell(x, y));
                }
            }
            _robot = new Robot(this);
            _commandProcessor = new CommandProcessor(this);
            _ui = new UserInterface(this);
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
            _ui.PrintMessage("Welcome to the Toy Robot simulator!");
            string input = _ui.AskUser("Would you like a GUI? ").ToUpper();
            _gui = input == "Y" || input == "YES" || input == "T" || input == "TRUE";
            _playing = true;
            while (_playing)
            {
                if (_gui)
                    _ui.PrintGrid();
                string command = _ui.AskUser("What would you like to do? ");
                _commandProcessor.Execute(command);
            }
            _ui.PrintMessage("Thanks for playing!");
        }

        /// <summary>Ends the game</summary>
        public void Stop()
        {
            _playing = false;
        }
    }
}