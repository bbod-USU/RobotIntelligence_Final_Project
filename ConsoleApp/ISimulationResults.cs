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
        List<ICell> SquarePath { get; set; }
        List<ICell> SquareMappedBombs { get; set; }
        int SquareCellsUncleared { get; set; }
        int SquareCellsCleared { get; set; }
        int SquareBombsFound { get; set; }
        int SquareTotalMoves { get; set; }
        List<ICell> SquareCoveredCells { get; set; }
        List<Coordinate2D> HexCoveredCells { get; set; }
    }
}