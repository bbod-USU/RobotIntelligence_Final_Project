using System;

namespace ConsoleApp.Maps
{
    public enum Coverage
    {
        Uncoverd,
        Covered
    }
    public struct Cell : ICell
    {
        public int X { get; }
        public int Y { get; }
        public Coverage Coverage { get; set; }
        
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Coverage = Coverage.Uncoverd;
        }

        
    }
}