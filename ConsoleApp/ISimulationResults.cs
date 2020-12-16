using System.Collections.Generic;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp
{
    public interface ISimulationResults
    {
        void WriteResults();
        int HexTotalMoves { get; set; }
        int HexBombsFound { get; set; }
        int TotalBombs { get; set; }
        List<Coordinate2D> HexPath { get; set; }
        List<Coordinate2D> HexMappedBombs { get; set; }
        List<Cell> Mines { get; set; }
        int HexClearedCells { get; set; }
        int HexUnClearedCells { get; set; }
    }
}