using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using HexCore;


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

            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Map[i,j] = new Cell(i, j);
                }
            }
            
            //set Starting cell;
            StartingCell = GetCell(0,0);
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
        
        public List<ICell> GetShortestPath(ICell start, ICell goal)
        {
            return AstarSquareSearch.FindShortestPath(this, start, goal);
        }

        public List<Cell> GetRange(ICell centerCell, int radius)
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

        public List<ICell> GetPassableNeighbors(ICell cell) => 
            GetNeighbors(cell).Where(neighbor => !neighbor.Blocked).Cast<ICell>().ToList();
        
        
        private static int ComputeHScore(ICell src, Cell dest)
        {
            return Math.Abs(dest.X - src.X) + Math.Abs(dest.Y - src.Y);
        }
        

        public List<Cell> GetNeighbors(ICell cell)
        {
            var rlist = new List<Cell>();
            var rowOperations = new int[] { -1, 0, 0, 1};
            var colOperations = new int[] {0, -1, 1, 0};
            for (var i = 0; i < 4; i++)
            {
                var curCell = GetCell(cell.X + rowOperations[i], cell.Y + colOperations[i]);
                if (curCell != default)
                {
                    rlist.Add(curCell);
                }
            }
            return rlist;
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
            if (cy - radius < 0) bottomY = 0;
            else
                bottomY = cy - radius;
            if (cx + radius > Width) bottomX = Width;
            else
                bottomX = cx + radius;
            return Map[bottomX, bottomY];
        }

        public Cell GetCell(int x, int y)
        {
            if (x > Width || y > Height || x < 0 || y < 0)
                return default;
            return Map[x, y];
        }

    }
}