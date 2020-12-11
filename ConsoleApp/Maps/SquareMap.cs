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

        public List<ICell> PossibleMoves(SquareCell myCell)
        {
            var forward = (myCell.X , myCell.Y + 1);
            var backwards= (myCell.X , myCell.Y - 1);
            var right = (myCell.X + 1, myCell.Y);
            var left = (myCell.X - 1, myCell.Y);
            var possibles = new List<ICell>();
            possibles.Add(Map[forward.Item1, forward.Item2]);
            possibles.Add(Map[backwards.Item1, backwards.Item2]);
            possibles.Add(Map[right.Item1, right.Item2]);
            possibles.Add(Map[left.Item1, left.Item2]);
            
            return possibles;
        }
    }
}