using System;
using System.Linq;
using System.Collections.Generic;

namespace ToyRobotConsole
{
    /// <summary>
    /// The CommandProcessor class takes a command string, validates that it contains known commands
    /// and manages propagation of commands to the correct game elements.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>Private field for game.</summary>
        Game _game;

        /// <summary>Command Processor constructor</summary>
        /// <param name="game">A game parameter to manage command propagation</param>
        public CommandProcessor(Game game)
        {
            _game = game;
        }

        /// <summary>Provides a list of suggestions for known commands</summary>
        /// <returns>A string representation of a list of known commands</returns>
        private string Help()
        {
            return "I'm not sure how to process that command. Try one of these:\n"
                + "PLACE 0,0,NORTH\n"
                + "MOVE\n"
                + "LEFT\n"
                + "RIGHT\n"
                + "REPORT\n"
                + "QUIT";
        }

        /// <summary>Validates the remaining command string and propagates to robot</summary>
        /// <param name="command">A string containing the parameters of the place command</param>
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

        /// <summary>Validates the command string and propagates to appropriate game object</summary>
        /// <param name="command">A string containing the command</param>
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
                        Console.WriteLine(Help());
                        break;
                }
            }
        }
    }
}