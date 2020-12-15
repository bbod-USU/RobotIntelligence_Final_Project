using System.Collections.Generic;
using ConsoleApp.Maps;

namespace ConsoleApp
{
    public interface IPathPlanner
    {
        Queue<ICell> GenerateOptimalSquarePath(SquareMap map, IVehicle vehicle);
    }
    
}