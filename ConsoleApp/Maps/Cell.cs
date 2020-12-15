using System;

namespace ConsoleApp.Maps
{
    public struct Cell : ICell
    {
        public int X { get; }
        public int Y { get; }


        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        
    }
}