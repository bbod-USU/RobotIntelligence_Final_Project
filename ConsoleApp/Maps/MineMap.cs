using System;
using System.Collections.Generic;
using System.IO;
using HexCore;

namespace ConsoleApp.Maps
{
    public class MineMap : IMineMap
    {
        private int _mineCount;
        private int _x;
        private int _y;
        public bool[,] Map { get; }
        public int TotalBombs { get; }
        private List<Cell> _placedMines;

        public MineMap(int x, int y, double minePercentage)
        {
            _x = x;
            _y = y;
            _placedMines = new List<Cell>();
            _mineCount = (int)(x*y*(minePercentage/100));
            TotalBombs = _mineCount;
            Map = new bool[x, y];
            Map.Fill2DArray(false);
            PlaceMines();
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/Mines.txt"))
            {
                foreach (var s in _placedMines)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
        }
        public bool GetCell(int x, int y) => Map[x,y];


        private void PlaceMines()
        {
            var rand = new Random();
            for (var i = 0; i < _mineCount; i++) 
            {
                var x = rand.Next(5,_x-5);
                var y = rand.Next(5,_y-5);
                if (Map[x, y] == true)
                {
                    i--;
                }
                else
                {
                    Map[x, y] = true;
                    _placedMines.Add(new Cell(x,y));
                }
            }
        }
    }
}