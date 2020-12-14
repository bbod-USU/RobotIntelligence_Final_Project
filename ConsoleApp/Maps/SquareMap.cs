using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class SquareMap : ISquareMap
    {
        public Cell[,] Map { get;}
        public ICell StartingCell { get; }
        public ICell LastCell { get; }

        public SquareMap(int x, int y)
        {
            //convert to cm
            x *= 100;
            y *= 100;
            //calculate number of cells on x and y axis
            var xCellCount = (int)Math.Ceiling((decimal) (x) / 25);
            var yCellCount = (int)Math.Ceiling((decimal) (y) / 25);
            
            //set last cell;
            StartingCell = Map[0, 0];
            Map = new Cell[xCellCount, yCellCount];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Map[i,j] = new Cell(i, j);
                }
            }
        }

        public List<ICell> PossibleMoves(ICell currentCell)
        {
            var forward = (currentCell.X , currentCell.Y + 1);
            var backwards= (currentCell.X , currentCell.Y - 1);
            var right = (currentCell.X + 1, currentCell.Y);
            var left = (currentCell.X - 1, currentCell.Y);
            var possibles = new List<ICell>();
            possibles.Add(Map[forward.Item1, forward.Item2]);
            possibles.Add(Map[backwards.Item1, backwards.Item2]);
            possibles.Add(Map[right.Item1, right.Item2]);
            possibles.Add(Map[left.Item1, left.Item2]);
            
            return possibles;
        }
    }
}