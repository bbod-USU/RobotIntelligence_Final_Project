using System;

namespace ConsoleApp.Maps
{
    public enum Coverage
    {
        //Order here matters these are cast to ints for the heuristic algorithm
        Uncovered,
        Covered
    }
    public class Cell : ICell
    {
        public int X { get; }
        public int Y { get; }
        public Coverage Coverage { get; set; }
        public bool Blocked { get; set; }
        
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Coverage = Coverage.Uncovered;
            Blocked = false;
        }

        
    }
}