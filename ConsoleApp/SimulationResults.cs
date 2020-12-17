using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp
{
    public class SimulationResults : ISimulationResults
    {
        public int HexTotalMoves { get; set; }
        public int HexBombsFound { get; set; }
        public int TotalBombs { get; set; }
        public List<Coordinate2D> HexPath { get; set; }
        public List<Coordinate2D> HexMappedBombs { get; set; }
        public List<Cell> Mines { get; set; }
        public int HexClearedCells { get; set; }
        public int HexUnClearedCells { get; set; }
        
        public List<ICell> SquarePath { get; set; }
        public List<ICell> SquareMappedBombs { get; set; }
        public int SquareCellsUncleared { get; set; }
        public int SquareCellsCleared { get; set; }
        public int SquareBombsFound { get; set; }
        public int SquareTotalMoves { get; set; }
        public List<ICell> SquareCoveredCells { get; set; }
        public List<Coordinate2D> HexCoveredCells { get; set; }

        public SimulationResults()
        {
            HexTotalMoves = 0;
            HexBombsFound = 0;
            TotalBombs = 0;
            HexPath = new List<Coordinate2D>();
            HexMappedBombs = new List<Coordinate2D>();
            Mines = new List<Cell>();
            HexClearedCells = 0;
            HexUnClearedCells = 0;
            SquarePath = new List<ICell>();
            SquareMappedBombs = new List<ICell>();
            SquareCellsUncleared = 0;
            SquareCellsCleared = 0;
            SquareBombsFound = 0;
            SquareTotalMoves = 0;
            SquareCoveredCells = new List<ICell>();
            HexCoveredCells = new List<Coordinate2D>();

        }

        public void WriteResults()
        {
            WriteData();
            WriteMines();
            WritePaths();
            WriteDetectedMines();
            WriteCoveredCells();
        }
        

        private void WriteData()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/Data.txt"))
            {
                tw.WriteLine($"General:");
                tw.WriteLine($"\t Total Mines: {TotalBombs}");
                tw.WriteLine($"Hex: ");
                tw.WriteLine($"\t Total Moves: {HexTotalMoves}");
                tw.WriteLine($"\t Bombs Found: {HexBombsFound}");
                tw.WriteLine($"\t Cleared Cell Count: {HexClearedCells}");
                tw.WriteLine($"\t Uncleared Cell Count: {HexUnClearedCells}");
                tw.WriteLine($"\t Percentage Cleared: {(double)HexClearedCells/(HexClearedCells+HexUnClearedCells)*100}");
                tw.WriteLine($"Square: ");
                tw.WriteLine($"\t Total Moves: {SquareTotalMoves}");
                tw.WriteLine($"\t Bombs Found: {SquareBombsFound}");
                tw.WriteLine($"\t Cleared Cell Count: {SquareCellsCleared}");
                tw.WriteLine($"\t Uncleared Cell Count: {SquareCellsUncleared}");
                tw.WriteLine($"\t Percentage Cleared: {(double) SquareCellsCleared / (SquareCellsCleared + SquareCellsUncleared)*100}");

            }
        }

       
        
        private void WriteMines()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/Mines.txt"))
            {
                foreach (var s in Mines)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
        }

        private void WriteCoveredCells()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexCoveredCells.txt"))
            {
                foreach (var s in HexCoveredCells)
                    tw.WriteLine($"{s.X} {s.Y}");
            }        
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareCoveredCells.txt"))
            {
                foreach (var s in SquareCoveredCells)
                    tw.WriteLine($"{s.X} {s.Y}");
            }        
        }
        
        private void WriteDetectedMines()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexDetectedMines.txt"))
            {
                foreach (var s in HexMappedBombs)
                    tw.WriteLine($"{s.X} {s.Y}");
            }        
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquareDetectedMines.txt"))
            {
                foreach (var s in SquareMappedBombs)
                    tw.WriteLine($"{s.X} {s.Y}");
            }        
        }

        private void WritePaths()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexPath.txt"))
            {
                foreach (var s in HexPath)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SquarePath.txt"))
            {
                foreach (var s in SquarePath)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
            
        }
    }
}