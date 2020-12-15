using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class HexMap : IHexMap
    {
        public Cell[,] Map { get; }
        public Cell StartingCell { get; }
        public Cell LastCell { get; }

        /// <summary>
        /// Generate Hex map with cells of 25cm X 25cm
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public HexMap(int x, int y)
        {
            //convert to cm
            x *= 100;
            y *= 100;
            //calculate number of cells on x and y axis
            var xCellCount = (int)Math.Ceiling((decimal) (x) / 25);
            var yCellCount = (int)Math.Ceiling((decimal) (y) / 25);
            
            //Initialize Map
            Map = new Cell[xCellCount, yCellCount];

            //set last cell;
            StartingCell = Map[0, 0];
            for (int r = 0; r < yCellCount; r++) {
                int r_offset = Convert.ToInt32(Math.Floor(Convert.ToDouble(r)/2));
                for (int q = r_offset; q < xCellCount - r_offset; q++) {
                    // Console.WriteLine($"r:{r}, q:{q}-----x:{x}, y:{y}");
                    Map[r, q] = new Cell(q, r, -q-r);
                }
            }
        }

        public List<GlobalDirection> PossibleMoves(ICell currentCell)
        {
            throw new NotImplementedException();
        }
    }
}