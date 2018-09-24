using System;
using System.Linq;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    public class CommandProcessor
    {
        Game _game;
        public CommandProcessor(Game game)
        {
            _game = game;
        }

        private void Place(string command)
        {
            int firstParamIndex = command.IndexOf(" ") + 1;
            string paramsStr = command.Substring(firstParamIndex);
            List<string> paramsList = paramsStr.Split(',').Select(w => w.Trim()).ToList();
            try
            {
                int x = Convert.ToInt32(paramsList[0]);
                int y = Convert.ToInt32(paramsList[1]);
                Direction direction = (Direction) Enum.Parse(typeof(Direction), paramsList[2]);
                _game.Robot.Place(x, y, direction);
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot PLACE like that! Please check parameters.");
            }
        }

        public void Execute(string command)
        {
            string upperCommand = command.ToUpper();
            if (upperCommand.Contains("PLACE"))
                Place(upperCommand);
            else
            {
                switch (upperCommand)
                {
                    case "MOVE":
                        _game.Robot.Move();
                        break;
                    case "LEFT":
                        _game.Robot.Left();
                        break;
                    case "RIGHT":
                        _game.Robot.Right();
                        break;
                    case "REPORT":
                        _game.Robot.Report();
                        break;
                    case "QUIT":
                        _game.Stop();
                        break;
                    default:
                        Console.WriteLine("I'm not sure how to process that command.");
                        break;
                }
            }
        }
    }
}