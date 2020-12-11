using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class HexMap
    {
        private HexCell[,] Map { get; }

        public HexMap(int x, int y)
        {
            for (int r = 0; r < y; r++) {
                int r_offset = Convert.ToInt32(Math.Floor(Convert.ToDouble(r)/2));
                for (int q = -r_offset; q < x - r_offset; q++) {
                    Map[r, q] = new HexCell(q, r, -q-r);
                }
            }
        }

        public List<HexCell> PossibleMoves(HexCell fromCell, Direction direction, Double orientation)
        {
            
        }
    }
}