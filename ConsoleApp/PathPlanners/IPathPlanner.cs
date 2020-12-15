using System.Collections.Generic;
using ConsoleApp.Maps;

namespace ConsoleApp.PathPlanners
{
    public interface IPathPlanner
    {
        Queue<ICell> GenerateOptimalSquarePath(ISquareMap map, IVehicle vehicle);
        Queue<ICell> GenerateOptimalHexPath(HexMap hexMap, IVehicle vehicle);
    }
    
}