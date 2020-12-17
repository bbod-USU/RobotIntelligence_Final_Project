using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Maps;
using ConsoleApp.Sim;
using HexCore;

namespace ConsoleApp.PathPlanners
{
    public class PathPlanner : IPathPlanner
    {
        public Queue<ICell> GenerateOptimalSquarePath(ISquareMap map, IVehicle vehicle)
        {
            var currentPostion = vehicle.CurrentSquareCell;
            var currentHeading = GlobalDirection.East;
            var finished = false;
            var path = new List<ICell>();
            while (!finished)
            {
                //Heading East
                if (currentHeading == GlobalDirection.East)
                {
                    path.AddRange(
                        map.GetShortestPath(currentPostion, map.GetCell(map.Width - 1, currentPostion.Y)));
                    currentPostion = new Cell(map.Width - 1, currentPostion.Y);
                }
                //Heading West
                else if (currentHeading == GlobalDirection.West)
                {
                    path.AddRange(
                        map.GetShortestPath(currentPostion, map.GetCell(0, currentPostion.Y)));
                    currentPostion = new Cell(0, currentPostion.Y);
                }
                //Check for finish
                if (currentPostion.Y + (vehicle.DetectorRadius * 2) >= map.Height)
                {
                    finished = true;
                    continue;
                }
                
                //Move up X Axis
                path.AddRange(
                    map.GetShortestPath(
                        currentPostion, 
                        map.GetCell(currentPostion.X, currentPostion.Y + vehicle.DetectorRadius * 2 - 1)));

                currentPostion = new Cell(currentPostion.X, currentPostion.Y + (vehicle.DetectorRadius * 2 - 1));
                if (currentHeading == GlobalDirection.East)
                    currentHeading = GlobalDirection.West;
                else
                    currentHeading = GlobalDirection.East;
                
            }


            return new Queue<ICell>(path);
        }

        public Queue<Coordinate2D> GenerateOptimalHexPath(IHexMap hexMap, IVehicle vehicle)
        {
            var currentPostion = vehicle.CurrentHexCell;
            var currentHeading = GlobalDirection.East;
            var finished = false;
            var path = new List<Coordinate2D>();
            while (!finished)
            {
                //Heading East
                if (currentHeading == GlobalDirection.East)
                {
                    path.AddRange(hexMap.Graph.GetShortestPath(
                        currentPostion,
                        new Coordinate2D(hexMap.Width-1, currentPostion.Y, hexMap.OffsetType),
                        hexMap.DefaultMovement));
                    currentPostion = new Coordinate2D(hexMap.Width-1, currentPostion.Y, hexMap.OffsetType);
                }
                //Heading West
                else if (currentHeading == GlobalDirection.West)
                {
                    path.AddRange(hexMap.Graph.GetShortestPath(
                        currentPostion,
                        new Coordinate2D(0, currentPostion.Y, hexMap.OffsetType),
                        hexMap.DefaultMovement));
                    currentPostion = new Coordinate2D(0, currentPostion.Y, hexMap.OffsetType);
                
                }

                //Check for finish
                if (currentPostion.Y + (vehicle.DetectorRadius * 2) >= hexMap.Height - 1)
                {
                    finished = true;
                    break;
                }

                //Move Up edges of map
                var tmpPosition = currentPostion;
                var range = hexMap.Graph.GetRange(currentPostion, vehicle.DetectorRadius * 2);
                for (var i = currentPostion.Y; i < currentPostion.Y + vehicle.DetectorRadius * 2; i++)
                {
                    var newCoord = new Coordinate2D(currentPostion.X, i, hexMap.OffsetType);
                    if (range.Contains(newCoord))
                        tmpPosition = newCoord;
                   
                }
                
                path.AddRange(hexMap.Graph.GetShortestPath(
                    currentPostion,
                    tmpPosition,
                    hexMap.DefaultMovement));
                currentPostion = tmpPosition;
                if (currentHeading == GlobalDirection.East)
                    currentHeading = GlobalDirection.West;
                else
                    currentHeading = GlobalDirection.East;
                
                
               
            }

            return new Queue<Coordinate2D>(path);
        }
    }
}