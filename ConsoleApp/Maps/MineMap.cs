using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class MineMap : IMineMap
    {
        private int _mineCount;
        private int _x;
        private int _y;
        public bool[,] Map { get; }
        public MineMap(int x, int y, double minePercentage)
        {
            _x = x;
            _y = y;
            _mineCount = x*y*((int)minePercentage/100);
            Map = new bool[x, y];
            Map.Fill2DArray(false);
            PlaceMines();
        }

        private void PlaceMines()
        {
            var rand = new Random();
            for (int i = 0; i < _mineCount; i++)
            {
                var x = rand.Next(_x);
                var y = rand.Next(_y);
                Map[x, y] = true;
            }
        }
    }
}