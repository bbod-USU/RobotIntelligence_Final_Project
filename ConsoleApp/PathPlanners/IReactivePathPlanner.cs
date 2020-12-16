using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public interface IReactivePathPlanner
    {
        Queue<Coordinate2D> ReactiveHexPath { get; }
    }
}