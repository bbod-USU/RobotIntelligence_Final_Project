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
            var path = new Queue<ICell>();
            var myCell = map.StartingCell;
            var finished = false;
            var width_cm = (double)(vehicle.DetectorRadius) * 100 * 2;
            var swathOffset = (int)Math.Floor((decimal) (width_cm) / 25) + 1;
            var currentHeading = GlobalDirection.North;
            while (!finished)
            {
                var availableMoves = map.PossibleMoves(myCell);
                if (availableMoves.Contains(GlobalDirection.North) && currentHeading == GlobalDirection.North &&
                    myCell.Y != map.Height)
                {
                    path.Enqueue(map.GetCell(myCell.X, myCell.Y + 1));
                    myCell = map.GetCell(myCell.X, myCell.Y + 1);
                }
                else if (availableMoves.Contains(GlobalDirection.South) && currentHeading == GlobalDirection.South && myCell.Y != 0)
                {
                    path.Enqueue(map.GetCell(myCell.X, myCell.Y - 1));
                    myCell = map.GetCell(myCell.X, myCell.Y - 1);
                }
                else
                {
                    if (myCell.X + swathOffset >= map.Width)
                    {
                        finished = true;
                    }
                    else
                    {
                        for (int i = myCell.X; i < myCell.X + swathOffset; i++)
                        {
                            path.Enqueue(map.GetCell(i, myCell.Y));
                        }
                        myCell = map.GetCell(myCell.X+swathOffset, myCell.Y);
                        if (currentHeading == GlobalDirection.North)
                            currentHeading = GlobalDirection.South;
                        else if (currentHeading == GlobalDirection.South)
                            currentHeading = GlobalDirection.North;
                    }
                }

            }

            return path;
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