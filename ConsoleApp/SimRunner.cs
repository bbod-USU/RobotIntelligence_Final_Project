using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Maps;

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
            // var hexTask = Task.Run(() => HexSimulation());
            // while(!squareTask.IsCompleted && !hexTask.IsCompleted){Thread.Sleep(500);}

        }

        private void HexSimulation()
        {
            var hexMap = (HexMap)_mapFactory.Maps["HexMap"];
            _vehicle.CurrentHexCell = hexMap.StartingCell;
        }
        

        private void SquareSimulation()
        {
            var squareMap = (SquareMap)_mapFactory.Maps["SquareMap"];
            _vehicle.CurrentSquareCell = squareMap.StartingCell;
            var optimalPath = _pathPlanner.GenerateOptimalSquarePath(squareMap, _vehicle);
        }

    }
}