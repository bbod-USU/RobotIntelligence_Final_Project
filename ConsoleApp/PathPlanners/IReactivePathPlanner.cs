using System.Collections.Generic;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public interface IReactivePathPlanner
    {
        Queue<Coordinate2D> ReactiveHexPath { get; }
        void GenerateReactiveHexPath(IHexMap hexMap, Queue<Coordinate2D> optimalPath, Coordinate2D vehicleCurrentHexCell);
        
        Queue<ICell> ReactiveSquarePath { get; }

        void GenerateReactiveSquarePath(ISquareMap squareMap, Queue<ICell> optimalPath,
            ICell vehicleCurrentSquareCell);
    }
}