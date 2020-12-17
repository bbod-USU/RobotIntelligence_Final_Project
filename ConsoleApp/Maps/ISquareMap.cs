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
        List<Cell> GetRange(ICell centerCell, int radius);
        List<Cell> GetNeighbors(ICell cell);
        List<ICell> GetPassableNeighbors(ICell cell);
        List<ICell> GetShortestPath(ICell start, ICell goal);
    }
}