using System;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public class Game
    {
        List<Cell> _map;
        Robot _robot;
        bool _playing;

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
                if (command.ToUpper() == "REPORT")
                    _robot.Report();
                if (command.ToUpper() == "QUIT")
                    Stop();
            }
            Console.WriteLine("Thanks for playing!");
        }

        public void Stop()
        {
            _playing = false;
        }
    }
}