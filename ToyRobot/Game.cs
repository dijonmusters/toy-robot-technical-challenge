using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public class Game
    {
        private List<Cell> _map;
        private Robot _robot;
        public Robot Robot { get { return _robot; } }
        private bool _playing;

        private CommandProcessor _commandProcessor;

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
            _robot = new Robot(_map);
            _commandProcessor = new CommandProcessor(this);
        }

        public Game() : this(5, 5)
        {}

        public void Start()
        {
            Console.WriteLine("Welcome to the Toy Robot simulator!");
            _playing = true;
            while (_playing)
            {
                Console.Write("What would you like to do? ");
                string command = Console.ReadLine();
                _commandProcessor.Execute(command);
            }
            Console.WriteLine("Thanks for playing!");
        }

        public void Stop()
        {
            _playing = false;
        }
    }
}