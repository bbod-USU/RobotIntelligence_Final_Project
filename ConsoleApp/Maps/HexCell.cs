using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public struct HexCell : IHexCell
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public HexCell(int q, int r, int s)
        {
            if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
            X = q;
            Y = r;
            Z = s;
        }
  
    }
}