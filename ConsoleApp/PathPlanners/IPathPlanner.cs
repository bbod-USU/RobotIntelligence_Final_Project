using System.Collections.Generic;
using ConsoleApp.Maps;
using ConsoleApp.Vehicle;

namespace ConsoleApp.PathPlanners
{
    public interface IPathPlanner
    {
        Queue<ICell> GenerateOptimalSquarePath(ISquareMap map, IVehicle vehicle);
        Queue<ICell> GenerateOptimalHexPath(IHexMap hexMap, IVehicle vehicle);
    }
    
}