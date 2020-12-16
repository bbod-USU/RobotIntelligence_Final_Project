using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Maps;
using ConsoleApp.PathPlanners;
using ConsoleApp.Sim;
using HexCore;
using ImTools;
using Microsoft.VisualBasic;

namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;
        private IVehicle _vehicle;

        private IPathPlanner _pathPlanner;
        private IMineMap _mineMap;
        private IReactivePathPlanner _reactivePathPlanner;
        private HashSet<Coordinate2D> hexBombsFound = new HashSet<Coordinate2D>();
        private List<Coordinate2D> testingPath = new List<Coordinate2D>();


        public SimRunner(IMapFactory mapFactory, IVehicle vehicle, IPathPlanner pathPlanner, IReactivePathPlanner reactivePathPlanner)
        {
            _mapFactory = mapFactory;
            _vehicle = vehicle;
            _pathPlanner = pathPlanner;
            _reactivePathPlanner = reactivePathPlanner;
        }

        public void Run()
        {
            _mineMap = _mapFactory.GetMineMap();
            SquareSimulation();
            HexSimulation();
            // while(!squareTask.IsCompleted && !hexTask.IsCompleted){Thread.Sleep(500);}

        }

        private void HexSimulation()
        {
            var hexMap = _mapFactory.GetHexMap();
            _vehicle.CurrentHexCell = new Coordinate2D(0, 0, OffsetTypes.OddRowsRight);
            var optimalPath = _pathPlanner.GenerateOptimalHexPath(hexMap, _vehicle);
            var minimumMoves = optimalPath.Count;
            var finished = false;
            var totalMoves = 0;
            while (!finished)
            {
                totalMoves += 1;
                testingPath.Add(_vehicle.CurrentHexCell);

                var detectionCells = DetectionHead.GetCoveredCells(hexMap.Graph, _vehicle.CurrentHexCell, _vehicle.DetectorRadius, _vehicle.TurnRadius);
                //Check Cells for mine
                var detection = CheckCells(detectionCells);
                //mark as cleared
                hexMap.Graph.SetCellsTerrainType(detectionCells, hexMap.ClearedTerrain);
                //Handle any detections
                if (detection)
                {
                    _reactivePathPlanner.GenerateReactiveHexPath(hexMap, optimalPath, _vehicle.CurrentHexCell);
                }
                
                //If the reactive Planner is not empty, empty it before the optimal.
                if (_reactivePathPlanner.ReactiveHexPath.TryDequeue(out var next))
                    _vehicle.CurrentHexCell = next;
                //Else we will work off of the optimal path
                else
                {
                    //If the optimal path is empty we are done otherwise pop.
                    if (!optimalPath.TryDequeue(out var nextOptimal))
                    {
                        finished = true;
                        break;
                    }

                    var replan = false;
                    //if the next optimal cell is blocked then we need to replan around it.
                    while (hexMap.Graph.IsCellBlocked(nextOptimal))
                    {
                        replan = true;
                        if (optimalPath.TryDequeue(out nextOptimal)) continue;
                        finished = true;
                        break;
                    }
                    if(replan)
                    {
                        var tmpPath =
                            hexMap.Graph.GetShortestPath(_vehicle.CurrentHexCell, nextOptimal, hexMap.DefaultMovement);
                        if (Math.Abs(_vehicle.CurrentHexCell.X - nextOptimal.X) > 1 || Math.Abs(_vehicle.CurrentHexCell.Y - nextOptimal.Y) > 1)
                            optimalPath.Dequeue();
                        tmpPath.AddRange(optimalPath);
                        
                        optimalPath.Clear();
                        foreach (var cell in tmpPath)
                        {
                            optimalPath.Enqueue(cell);
                        }
                        optimalPath.TryDequeue(out nextOptimal);
                    }

                    var last = testingPath[testingPath.Count-1];
                    if (Math.Abs(last.X - nextOptimal.X) > 1 || Math.Abs(last.Y - nextOptimal.Y) > 1)
                        Console.WriteLine("To big of a gap");
                  
                    _vehicle.CurrentHexCell = nextOptimal;
                }
            }
            
            
            //Debugging information
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/SavedList.txt"))
            {
                foreach (Coordinate2D s in testingPath)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
            using(TextWriter tw = new StreamWriter("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Output/DetectedMines.txt"))
            {
                foreach (Coordinate2D s in hexBombsFound)
                    tw.WriteLine($"{s.X} {s.Y}");
            }
            var covered = CoveredCells();
            Console.WriteLine($"Total cells traversed: {totalMoves} \n" +
                              $"Minimum required: {minimumMoves}");
            Console.WriteLine($"Total bombs found: {hexBombsFound.Count}/{_mineMap.TotalBombs}");
            
        }

        private int CoveredCells()
        {
            var hexMap = _mapFactory.GetHexMap();
            //for()
            return 0;
        }


        private bool CheckCells(List<Coordinate2D> detectionCells)
        {
            var found = false;
            foreach (var cell in detectionCells.Where(cell => _mineMap.GetCell(cell.X, cell.Y)))
            {
                if (!hexBombsFound.Add(cell)) continue;
                BlockCells(cell);
                found = true;
            }
            return found;
        }

        private void BlockCells(Coordinate2D cell)
        {
            var hexMap = _mapFactory.GetHexMap();
            var cellsToBlock = hexMap.Graph.GetRange(cell, _vehicle.Width / 2);
            hexMap.Graph.BlockCells(cellsToBlock);
            
            // //debugging
            // foreach (var celllll in cellsToBlock)
            // {
            //     Console.WriteLine($"({celllll.X}, {celllll.Y}) Blocked: {hexMap.Graph.GetCellState(celllll).IsBlocked}");    
            // }
        }


        private void SquareSimulation()
        {
            var squareMap = _mapFactory.GetSquareMap();
            _vehicle.CurrentSquareCell = squareMap.StartingCell;
            var optimalPath = _pathPlanner.GenerateOptimalSquarePath(squareMap, _vehicle);
        }

    }
}