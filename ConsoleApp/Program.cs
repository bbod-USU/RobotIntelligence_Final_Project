using System;
using ConsoleApp.Maps;

namespace ConsoleApp
{
    class Program
    {
        private static UserConsole _userConsole;
        private static BootStrapper _bootstrapper;

        static void Main(string[] args)
        {
            _bootstrapper = BootStrapper.BootstrapSystem(new CoreModule());
            _userConsole = new UserConsole();
            Initialization();
        }

        private static void Initialization()
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
                Initialization();
            }
        }

        private static void RunSimulation(int x,int y)
        {
            var mapFactory = _bootstrapper.Resolve<IMapFactory>();
            var simRunner = _bootstrapper.Resolve<ISimRunner>();
            
            mapFactory.GenerateMaps(x, y);
            simRunner.Run();
        }

    }
}