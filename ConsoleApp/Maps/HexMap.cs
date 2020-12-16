using System;
using System.Collections.Generic;
using System.Linq;
using HexCore;
using ImTools;

namespace ConsoleApp.Maps
{
    public class HexMap : IHexMap
    {

        public int Width { get; }

        public int Height { get; }

        public Graph Graph { get; }
        
        public OffsetTypes OffsetType { get; }
        public MovementType DefaultMovement { get; }
        public TerrainType ClearedTerrain { get; }

        public TerrainType UnclearedTerrain { get; }


        /// <summary>
        /// Generate Hex map with cells of 25cm X 25cm
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public HexMap(int x, int y)
        {
            //Set Offset Type for 2d -> 3d conversion
            OffsetType = OffsetTypes.OddRowsRight;

            Height = y;
            Width = x;
            
            UnclearedTerrain = new TerrainType(1, "uncleared");
            ClearedTerrain = new TerrainType(2, "cleared");
            
            DefaultMovement = new MovementType(1, "default");
            var movementTypes = new MovementTypes(
                new ITerrainType[] { UnclearedTerrain, ClearedTerrain }, 
                new Dictionary<IMovementType, Dictionary<ITerrainType, int>>
                {
                    [DefaultMovement] = new Dictionary<ITerrainType, int>
                    {
                        [UnclearedTerrain] = 1,
                        [ClearedTerrain] = 2
                    }
                }
            );
            Graph = GraphFactory.CreateRectangularGraph(Width, Height, movementTypes, UnclearedTerrain);
        }


    }
}