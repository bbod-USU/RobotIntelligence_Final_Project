using System;

namespace ConsoleApp
{
    class Program
    {
        private static UserConsole _userConsole;

        static void Main(string[] args)
        {
            _userConsole = new UserConsole();
            StartSimulation();
        }

        private static void StartSimulation()
        {
            _userConsole.PrintStartMenu();
            var input = _userConsole.GetUserInput();
            if (input == "1")
            {
                var (x,y) = _userConsole.GetMapDimensions();
                RunSimulation(x, y);
            }
            else
            {
                _userConsole.PrintInvalidInput();
                StartSimulation();
            }
        }

        private static void RunSimulation(int x,int y)
        {
            var bootStrapper = new Bootstrapper
            var simRunner = new SimRunner();
        }

    }
}