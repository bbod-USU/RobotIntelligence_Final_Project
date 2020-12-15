using System;
using System.Collections.Generic;
using HexCore;
using ImTools;

namespace ConsoleApp.Maps
{
    public class SquareMap : ISquareMap
    {
        public Cell[,] Map { get;}
        public Cell StartingCell { get; }
        public Cell LastCell { get; }
        public int Height { get; }
        public int Width { get; }

        /// <summary>
        /// Returns a map with square cells
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public SquareMap(int x, int y)
        {
            HexGraph = default;
            //convert to cm
            x *= 100;
            y *= 100;
            //calculate number of cells on x and y axis
            var xCellCount = (int)Math.Ceiling((decimal) (x) / 25);
            var yCellCount = (int)Math.Ceiling((decimal) (y) / 25);
            
            //set Width and height Properties
            Width = xCellCount-1;
            Height = yCellCount-1;

            
            //Initialize Map
            Map = new Cell[xCellCount, yCellCount];

            //set last cell;
            StartingCell = Map[0, 0];
            for (int i = 0; i < xCellCount; i++)
            {
                for (int j = 0; j < yCellCount; j++)
                {
                    Map[i,j] = new Cell(i, j);
                }
            }
        }


        public List<GlobalDirection> PossibleMoves(ICell currentCell)
        {
            
            var possibles = new List<GlobalDirection>();
            if (currentCell.X != 0)
                possibles.Add(GlobalDirection.West);
            if (currentCell.X != Width)
                possibles.Add(GlobalDirection.East);
            if (currentCell.Y != Height)
                possibles.Add(GlobalDirection.North);
            if (currentCell.Y != 0)
                possibles.Add(GlobalDirection.South);

            return possibles;
        }
        
        public Graph HexGraph { get; }

        public Cell GetCell(int x, int y) => Map[x, y];

    }
}