using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Maps;
using ConsoleApp.PathPlanners;
using ConsoleApp.Sim;
using HexCore;

namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;
        private IVehicle _vehicle;

        private int _cellWidth;
        private IPathPlanner _pathPlanner;
        private IMineMap _mineMap;
        private IReactivePathPlanner _reactivePathPlanner;


        public SimRunner(IMapFactory mapFactory, IVehicle vehicle, IPathPlanner pathPlanner, IReactivePathPlanner reactivePathPlanner)
        {
           
            _cellWidth = mapFactory.CellWidth;
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
            var reactivePath = _reactivePathPlanner.ReactiveHexPath;
        }
        

        private void SquareSimulation()
        {
            var squareMap = _mapFactory.GetSquareMap();
            _vehicle.CurrentSquareCell = squareMap.StartingCell;
            var optimalPath = _pathPlanner.GenerateOptimalSquarePath(squareMap, _vehicle);
        }

    }
}