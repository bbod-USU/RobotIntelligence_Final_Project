using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Maps;
using ConsoleApp.PathPlanners;
using HexCore;

namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;
        private IVehicle _vehicle;

        private int _cellWidth;
        private IPathPlanner _pathPlanner;


        public SimRunner(IMapFactory mapFactory, IVehicle vehicle, IPathPlanner pathPlanner)
        {
           
            _cellWidth = mapFactory.CellWidth;
            _mapFactory = mapFactory;
            _vehicle = vehicle;
            _pathPlanner = pathPlanner;
        }

        public void Run()
        {

            SquareSimulation();
            HexSimulation();
            // while(!squareTask.IsCompleted && !hexTask.IsCompleted){Thread.Sleep(500);}

        }

        private void HexSimulation()
        {
            var hexMap = _mapFactory.GetHexMap();
            _vehicle.CurrentHexCell = new Coordinate2D(0, 0, OffsetTypes.OddRowsRight);
            //var optimalPath = _pathPlanner.GenerateOptimalHexPath(hexMap, _vehicle);
        }
        

        private void SquareSimulation()
        {
            var squareMap = _mapFactory.GetSquareMap();
            _vehicle.CurrentSquareCell = squareMap.StartingCell;
            var optimalPath = _pathPlanner.GenerateOptimalSquarePath(squareMap, _vehicle);
        }

    }
}