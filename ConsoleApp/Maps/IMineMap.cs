using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public interface IMineMap
    {
        bool[,] Map { get; }
        
        int TotalBombs { get; }
        bool GetCell(int x, int y);
        List<Cell> PlacedMines { get; }
    }
}