using System.Collections.Generic;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public class ReactivePathPlanner : IReactivePathPlanner
    {
        private Queue<Coordinate2D> _reactiveHexPath;
        private Queue<ICell> _reactiveSquarePath;
        public Queue<Coordinate2D> ReactiveHexPath => _reactiveHexPath;
        public Queue<ICell> ReactiveSquarePath => _reactiveSquarePath;

        

        public ReactivePathPlanner()
        {
            _reactiveHexPath = new Queue<Coordinate2D>();
            _reactiveSquarePath = new Queue<ICell>();

        }
        public void GenerateReactiveHexPath(IHexMap hexMap, Queue<Coordinate2D> optimalPath,
            Coordinate2D vehicleCurrentHexCell)
        {
            //Clean out any old path
            _reactiveHexPath.Clear();
            
            //If the optimal path is empty well we are done, otherwise pop 1
            if (!optimalPath.TryDequeue(out var convergentPoint))
                return;

            //Dequeue until the cell is not blocked
            while (hexMap.Graph.IsCellBlocked(convergentPoint))
            {
                //if optimal path is empty were done and we can not clear around this position, otherwise
                //lest pop another.
                if (!optimalPath.TryDequeue(out convergentPoint))
                    return;
            }

            var reactivePath = hexMap.Graph.GetShortestPath(vehicleCurrentHexCell, convergentPoint, hexMap.DefaultMovement);
            foreach (var node in reactivePath)
            {
                _reactiveHexPath.Enqueue(node);
            }
        }


        public void GenerateReactiveSquarePath(ISquareMap squareMap, Queue<ICell> optimalPath,
            ICell vehicleCurrentSquareCell)
        {
            //Clean out old path
            _reactiveSquarePath.Clear();
            
            //If the optimal path is empty well we are done, otherwise pop 1
            if (!optimalPath.TryDequeue(out ICell convergentPoint))
                return;

            //Dequeue until the cell is not blocked
            while (squareMap.GetCell(convergentPoint.X, convergentPoint.Y).Blocked)
            {
                //if optimal path is empty were done and we can not clear around this position, otherwise
                //lest pop another.
                if (!optimalPath.TryDequeue(out convergentPoint))
                    return;
            }

            var map = (SquareMap)squareMap;
            var reactivePath = map.GetShortestPath(vehicleCurrentSquareCell, convergentPoint);
            foreach (var node in reactivePath)
            {
                _reactiveSquarePath.Enqueue(node);
            }
        }
    }
}