using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class SquareMap : ISquareMap
    {
        public SquareCell[,] Map { get;}

        public SquareMap(int x, int y)
        {
            Map = new SquareCell[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Map[i,j] = new SquareCell(i, j);
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