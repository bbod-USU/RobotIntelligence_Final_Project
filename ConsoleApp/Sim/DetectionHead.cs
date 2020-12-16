using System.Collections.Generic;
using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp.Sim
{
    public static class DetectionHead
    {
        public static List<Coordinate2D> GetCoveredCells(
            Graph graph,
            Coordinate2D centerCoordinate,
            int detectorRadius,
            int vehicleTurnRadius)
        {
            var detectorCells = graph.GetRange(centerCoordinate, detectorRadius);
            // var vehicleCells = graph.GetRange(centerCoordinate, vehicleTurnRadius);
            // foreach (var vehicleCell in vehicleCells)
            // {
            //     detectorCells.Remove(vehicleCell);
            // }
            return detectorCells;
        }

        public static List<Cell> GetCoveredCells(
            ISquareMap squareMap,
            Cell centerCell,
            int detectorRadius) => squareMap.GetRange(centerCell, detectorRadius);
    }
}