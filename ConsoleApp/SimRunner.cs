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
        private ISimulationResults _simulationResults;


        public SimRunner(IMapFactory mapFactory, IVehicle vehicle, IPathPlanner pathPlanner, IReactivePathPlanner reactivePathPlanner, ISimulationResults simulationResults)
        {
            _mapFactory = mapFactory;
            _vehicle = vehicle;
            _pathPlanner = pathPlanner;
            _reactivePathPlanner = reactivePathPlanner;
            _simulationResults = simulationResults;
        }

        public void Run()
        {
            _mineMap = _mapFactory.GetMineMap();
            _simulationResults.Mines = _mineMap.PlacedMines;
            _simulationResults.TotalBombs = _mineMap.TotalBombs;
            SquareSimulation();
            HexSimulation();
            // while(!squareTask.IsCompleted && !hexTask.IsCompleted){Thread.Sleep(500);}

        }

        private void HexSimulation()
        {
            var hexMap = _mapFactory.GetHexMap();
            _vehicle.CurrentHexCell = new Coordinate2D(0, 0, OffsetTypes.OddRowsRight);
            var optimalPath = _pathPlanner.GenerateOptimalHexPath(hexMap, _vehicle);
            var finished = false;
            var totalMoves = 0;
            while (!finished)
            {
                totalMoves += 1;
                _simulationResults.HexPath.Add(_vehicle.CurrentHexCell);

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

                    if (hexMap.Graph.IsCellBlocked(nextOptimal))
                    {
                        _reactivePathPlanner.GenerateReactiveHexPath(hexMap, optimalPath, _vehicle.CurrentHexCell);
                    }
                    else
                        _vehicle.CurrentHexCell = nextOptimal;
                }
            }
            
            
            //Debugging information
            var (cleared, uncleared) = CoveredCells();
            _simulationResults.HexClearedCells = cleared;
            _simulationResults.HexUnClearedCells = uncleared;
            _simulationResults.HexTotalMoves = totalMoves;
            _simulationResults.HexBombsFound = hexBombsFound.Count;
        }

        private (int, int) CoveredCells()
        {
            var cleared = 0;
            var uncleared = 0;
            var hexMap = _mapFactory.GetHexMap();
            foreach (var cellState in hexMap.Graph.GetAllCells())
            {
                if (cellState.TerrainType.Id == hexMap.ClearedTerrain.Id)
                    cleared++;
                if (cellState.TerrainType.Id == hexMap.UnclearedTerrain.Id)
                    uncleared++;
            }

            return (cleared, uncleared);
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
            
        }


        private void SquareSimulation()
        {
            var squareMap = _mapFactory.GetSquareMap();
            _vehicle.CurrentSquareCell = squareMap.StartingCell;
            var optimalPath = _pathPlanner.GenerateOptimalSquarePath(squareMap, _vehicle);
        }

    }
}