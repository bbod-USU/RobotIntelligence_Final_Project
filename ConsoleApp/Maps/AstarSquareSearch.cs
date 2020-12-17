using System;
using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.Maps
{
    public class AstarSquareSearch
    {
        private static double Heuristic(ICell a, ICell b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static List<ICell> FindShortestPath(ISquareMap graph, ICell start, ICell goal)
        {
            var costSoFar = new Dictionary<ICell, int>();
            var cameFrom = new Dictionary<ICell, ICell>();
            var frontier = new PriorityQueue<ICell>();

            frontier.Enqueue(start, 0);
            cameFrom[start] = start;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current.Equals(goal)) break;

                foreach (var next in graph.GetPassableNeighbors(current))
                {
                    var newCost = costSoFar[current] + (int)graph.GetCell(next.X, next.Y).Coverage;
                    if (costSoFar.ContainsKey(next) && newCost >= costSoFar[next]) continue;
                    costSoFar[next] = newCost;
                    var priority = newCost + Heuristic(next, goal);
                    frontier.Enqueue(next, priority);
                    cameFrom[next] = current;
                }
            }

            var path = new List<ICell>();
            var pathWasNotFound = !cameFrom.ContainsKey(goal);

            // Returning an empty list if the path wasn't found
            if (pathWasNotFound) return path;

            // Reconstructing path
            var curr = goal;
            while (!curr.Equals(start))
            {
                path.Add(curr);
                curr = cameFrom[curr];
            }

            // Reverse it to start at actual start point
            path.Reverse();
            return path;
        }
    }
}