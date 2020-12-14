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
        private IMap _squareMap;
        private IMap _hexMap;
        private int _cellWidth;


        public SimRunner(IMapFactory mapFactory, IVehicle vehicle)
        {
            _squareMap = mapFactory.Maps["SquareMap"];
            _hexMap = mapFactory.Maps["HexMap"];
            _cellWidth = mapFactory.CellWidth;
            _mapFactory = mapFactory;
            _vehicle = vehicle;
        }

        public void Run()
        {
            _vehicle.CurrentHexCell = _hexMap.StartingCell;
            _vehicle.CurrentSquareCell = _squareMap.StartingCell;
            var squareTask = Task.Run(() => SquareSimulation());
            var hexTask = Task.Run(() => HexSimulation());
            while(!squareTask.IsCompleted && !hexTask.IsCompleted){Thread.Sleep(500);}
           
        }

        private void HexSimulation()
        {
            
            var optimalPath = GenerateHexPath();
        }
        

        private void SquareSimulation()
        {
            var optimalPath = GenerateSquarePath();
        }

        private object GenerateSquarePath()
        {
            throw new NotImplementedException();
        }

        private Queue<ICell> GenerateHexPath()
        {
            var path = new Queue<ICell>();
            var currentCell = _vehicle.CurrentHexCell;
            var possibles = _hexMap.PossibleMoves(currentCell);
            while (currentCell != _hexMap.LastCell)
            {
                
            }

            return path;
        }
    }
}