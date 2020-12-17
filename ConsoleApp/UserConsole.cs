using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Maps;

namespace ConsoleApp
{
    public class UserConsole : IUserConsole
    {
        public UserConsole()
        {
        }

        public void PrintStartMenu()
        {
            Console.WriteLine($"Make a selection: \n" +
                              $"\t 1: Auto generate maps. \n" +
                              $"\t 2: Load custom map. \n");
        }

        public static string GetUserInput() => Console.ReadLine();

        public static void PrintInvalidInput() => Console.WriteLine($"Invalid input try again \n");

        public (int width, int height) GetMapDimensions()
        {
            Console.WriteLine($"Enter map width (5-15) meters: ");
            var x = GetUserInput();

            if (!int.TryParse(x, out var width) && width >= 5 && width <= 15)
            {
                PrintInvalidInput();
                GetMapDimensions();
            }

            Console.WriteLine($"Enter map height (5-15) meters: ");
            var y = GetUserInput();
            if (int.TryParse(y, out var height) && height >= 5 && height <= 15) return (width, height);
            PrintInvalidInput();
            GetMapDimensions();
            return (width, height);
        }

        public static double GetMinePercentage()
        {
            
            Console.WriteLine($"Enter desired percentage of mines: ");
            var x = GetUserInput();

            if (double.TryParse(x, out var percent)) return percent;
            PrintInvalidInput();
            GetMinePercentage();

            return percent;
        }
    }
}