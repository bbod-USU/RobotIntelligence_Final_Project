using System.Collections.Generic;
using ConsoleApp.Maps;
using ConsoleApp.Sim;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public interface IPathPlanner
    {
        Queue<ICell> GenerateOptimalSquarePath(ISquareMap map, IVehicle vehicle);
        Queue<Coordinate2D> GenerateOptimalHexPath(IHexMap hexMap, IVehicle vehicle);
    }
    
}