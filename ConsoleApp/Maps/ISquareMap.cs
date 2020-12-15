using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.Maps
{
    public interface ISquareMap
    {
        Cell[,] Map { get; }
        Cell StartingCell { get; }
        Cell LastCell { get; }
        List<GlobalDirection> PossibleMoves(ICell currentCell);
        Cell GetCell(int x, int y);
        int Height { get; }
        int Width { get; }
    }
}