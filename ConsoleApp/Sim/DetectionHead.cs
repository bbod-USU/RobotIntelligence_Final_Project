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
            GlobalDirection direction) => graph.GetRange(centerCoordinate, detectorRadius);

        public static List<Cell> GetCoveredCells(
            ISquareMap squareMap,
            Cell centerCell,
            int detectorRadius) => squareMap.GetRange(centerCell, detectorRadius);
    }
}