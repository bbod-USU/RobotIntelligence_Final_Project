using System;
using System.Collections.Generic;
using ConsoleApp.Maps;
using ConsoleApp.Vehicle;
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
        
        public Queue<ICell> GenerateOptimalHexPath(IHexMap hexMap, IVehicle vehicle)
        {
            // var t = hexMap.Graph.GetMovementRange(
            //     new Coordinate2D(0, 0, hexMap.OffsetType), 2, hexMap.DefaultMovement);
            // Console.WriteLine(t);
            throw new NotImplementedException();
        }
    }
}