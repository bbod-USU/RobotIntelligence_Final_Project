using System;
using System.Linq;

namespace ConsoleApp
{
    public class UserConsole : IUserConsole
    {
        private IMapFactory _mapFactory;

        public UserConsole()
        {
        }

        public void PrintStartMenu()
        {
            Console.WriteLine($"Make a selection: \n" +
                              $"\t 1: Auto generate maps. \n" +
                              $"\t 2: Load custom map. \n");
        }

        public string GetUserInput() => Console.ReadLine();

        public void PrintInvalidInput()
        {
            Console.WriteLine($"Invalid input try again \n");
        }

        public (int width, int height) GetMapDimensions()
        {
            Console.WriteLine($"Enter Dimensions of map/area to clear as (x, y)");
            var input = GetUserInput();
            var numbers = input.Split();
            if (numbers.Length != 4)
            {
                PrintInvalidInput();
                GetMapDimensions();
            }

            var parsedNumbers = numbers.Where(x => !(x.Equals("(") || x.Equals(")"))).ToList();
            int.TryParse(parsedNumbers[0], out var width);
            int.TryParse(parsedNumbers[1], out var height);
            return (width, height);
        }
    }
}