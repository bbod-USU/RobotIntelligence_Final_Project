using System;

namespace ConsoleApp.Maps
{
    public struct Cell : ICell
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Cell(int x, int y, int z = default)
        {
            if (z != default)
            {
                if (x + y + z != 0) throw new ArgumentException("x + y + z must be 0");
            }

            X = x;
            Y = y;
            Z = z;
        }
    }
}