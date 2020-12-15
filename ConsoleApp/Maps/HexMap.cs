using System;
using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.Maps
{
    public class HexMap : IHexMap
    {

        public int Width { get; }

        public int Height { get; }

        public Graph Graph { get; }

        /// <summary>
        /// Generate Hex map with cells of 25cm X 25cm
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public HexMap(int x, int y)
        {
            //convert to cm
            x *= 100;
            y *= 100;
            
            //calculate number of cells on x and y axis
            var xCellCount = (int)Math.Ceiling((decimal) (x) / 25);
            var yCellCount = (int)Math.Ceiling((decimal) (y) / 25);

            Height = yCellCount;
            Width = xCellCount;
            
            var unclearedTerrain = new TerrainType(1, "uncleared");
            var clearedTerrain = new TerrainType(2, "cleared");
            
            var movement = new MovementType(1, "default");
            var movementTypes = new MovementTypes(
                new ITerrainType[] { unclearedTerrain, clearedTerrain }, 
                new Dictionary<IMovementType, Dictionary<ITerrainType, int>>
                {
                    [movement] = new Dictionary<ITerrainType, int>
                    {
                        [unclearedTerrain] = 1,
                        [clearedTerrain] = 2
                    }
                }
            );
            Graph = GraphFactory.CreateRectangularGraph(Width, Height, movementTypes, unclearedTerrain);
        }

    }
}