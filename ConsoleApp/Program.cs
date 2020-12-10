using System;

namespace ConsoleApp
{
    class Program
    {
        private static UserConsole _userConsole;
        private static BootStrapper _bootstrapper;

        static void Main(string[] args)
        {
            _bootstrapper = new BootStrapper();
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
            var simRunner = _bootstrapper.Resolve<ISimRunner>();
            var mapFactory = _bootstrapper.Resolve<IMapFactory>();
            
            mapFactory.GenerateMaps(x, y);
            simRunner.Run();
        }

    }
}