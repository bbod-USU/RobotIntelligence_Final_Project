using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Maps;

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
            Console.WriteLine($"Enter map height: ");
            var x = GetUserInput();

            if (!int.TryParse(x, out var width))
            {
                PrintInvalidInput();
                GetMapDimensions();
            }

            Console.WriteLine($"Enter map height: ");
            var y = GetUserInput();
            if(!int.TryParse(y, out var height))
            {
                PrintInvalidInput();
                GetMapDimensions();
            }
            return (width, height);
        }
    }
}