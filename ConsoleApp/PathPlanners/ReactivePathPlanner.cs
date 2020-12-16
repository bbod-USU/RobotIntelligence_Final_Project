using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public class ReactivePathPlanner : IReactivePathPlanner
    {
        public Queue<Coordinate2D> ReactiveHexPath { get; }

        public ReactivePathPlanner()
        {
            ReactiveHexPath = new Queue<Coordinate2D>();
        }

        public void GenerateReactiveHexPath(Graph graph, ref List<Coordinate3D> optimalPath, Coordinate2D minePosition)
        {
            
        }
    }
}