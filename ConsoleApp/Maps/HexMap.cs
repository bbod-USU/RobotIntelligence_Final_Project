using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class HexMap : IHexMap
    {
        private HexCell[,] Map { get; }

        public HexMap(int x, int y)
        {
            Map = new HexCell[x+1,y+1];
            for (int r = 0; r < y; r++) {
                int r_offset = Convert.ToInt32(Math.Floor(Convert.ToDouble(r)/2));
                for (int q = r_offset; q < x - r_offset; q++) {
                    // Console.WriteLine($"r:{r}, q:{q}-----x:{x}, y:{y}");
                    Map[r, q] = new HexCell(q, r, -q-r);
                }
            }
        }

        public List<ICell> PossibleMoves(ICell currentCell)
        {
            throw new NotImplementedException();
        }
    }
}