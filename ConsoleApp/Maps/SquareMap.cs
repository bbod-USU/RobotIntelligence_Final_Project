using System;
using System.Collections.Generic;


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
  
            
            //set Width and height Properties
            Width = x-1;
            Height = y-1;

            
            //Initialize Map
            Map = new Cell[x, y];

            //set last cell;
            StartingCell = Map[0, 0];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
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

        public List<Cell> GetRange(Cell centerCell, int radius)
        {
            var inRange = new List<Cell>();
            var cx = centerCell.X;
            var cy = centerCell.Y;
            var topLeft = GetTopCellInBoundingBox(cx, cy, radius);
            var bottomRight = GetBottomCellInBoundingBox(cx, cy, radius);
            for (var i = topLeft.X; i < bottomRight.X; i++)
            {
                for (var j = bottomRight.Y; j < topLeft.Y; j++)
                {
                    if (Math.Pow(i - cx, 2) + Math.Pow(j - cy, 2) < Math.Pow(radius,2))
                    {
                        inRange.Add(Map[i,j]);
                    }
                }
            }
            return inRange;
        }

        private Cell GetTopCellInBoundingBox(int cx, int cy, int radius)
        {
            int topX, topY;
            if (cy + radius > Height) topY = Height;
            else
                topY = cy + radius;
            if (cx - radius < 0) topX = 0;
            else
                topX = cx - radius;
            return Map[topX, topY];
        }
        private Cell GetBottomCellInBoundingBox(int cx, int cy, int radius)
        {
            int bottomX, bottomY;
            if (cy - radius > 0) bottomY = 0;
            else
                bottomY = cy - radius;
            if (cx + radius < Width) bottomX = Width;
            else
                bottomX = cx + radius;
            return Map[bottomX, bottomY];
        }

        public Cell GetCell(int x, int y) => Map[x, y];

    }
}