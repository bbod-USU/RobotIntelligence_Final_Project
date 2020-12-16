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
        }

        public void WriteResults()
        {
            WriteData();
            WriteMines();
            WritePaths();
            WriteDetectedMines();
            GenerateImages();
        }
        
        private static void GenerateImages()
        {
            var file = Path.Combine("./",Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"HexPlot.py");
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "python3",
                Arguments = file,
                UseShellExecute = true
            };
            Process proc = new Process()
            {
                StartInfo = startInfo,
            };
            proc.Start();
            while (!proc.HasExited)
            {
                Thread.Sleep(500);
            }
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

        private void WriteDetectedMines()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexDetectedMines.txt"))
            {
                foreach (Coordinate2D s in HexMappedBombs)
                    tw.WriteLine($"{s.X} {s.Y}");
            }        
        }

        private void WritePaths()
        {
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/HexPath.txt"))
            {
                foreach (Coordinate2D s in HexPath)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
        }
    }
}