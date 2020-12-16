using System.Collections.Generic;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public class ReactivePathPlanner : IReactivePathPlanner
    {
        private Queue<Coordinate2D> _reactiveHexPath;
        public Queue<Coordinate2D> ReactiveHexPath => _reactiveHexPath;
        

        public ReactivePathPlanner()
        {
            _reactiveHexPath = new Queue<Coordinate2D>();
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
       
    }
}