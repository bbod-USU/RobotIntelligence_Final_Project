using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public struct HexCell
    {
        public int Q { get; }
        public int R { get; }
        public int S { get; }
        public HexCell(int q, int r, int s)
        {
            if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
            Q = q;
            R = r;
            S = s;
        }
  
    }
}