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
            Console.WriteLine("Program Completed");
        }

        private static void Initialization()
        {
            _userConsole.PrintStartMenu();
            var input = UserConsole.GetUserInput();
            if (input == "1")
            {
                var (x,y) = _userConsole.GetMapDimensions();
                var minePercentage = UserConsole.GetMinePercentage();
                RunSimulation(x, y, minePercentage);
            }
            else
            {
                UserConsole.PrintInvalidInput();
                Initialization();
            }
        }

        private static void RunSimulation(int x, int y, double minePercentage)
        {
            var mapFactory = _bootstrapper.Resolve<IMapFactory>();
            var simRunner = _bootstrapper.Resolve<ISimRunner>();
            
            mapFactory.GenerateMaps(x, y, minePercentage);
            simRunner.Run();
        }

    }
}