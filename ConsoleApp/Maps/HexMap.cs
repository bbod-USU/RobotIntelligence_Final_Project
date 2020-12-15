using System;
using System.Collections.Generic;
using HexCore;

namespace ConsoleApp.Maps
{
    public class HexMap : IHexMap
    {
        private int _mapHeight;
        private int _mapWidth;
        public Cell[,] Map { get; }
        public Cell StartingCell { get; }
        public Cell LastCell { get; }
        public Graph HexGraph { get; }

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

            _mapHeight = yCellCount;
            _mapWidth = xCellCount;
            
            //Initialize Map
            Map = new Cell[xCellCount, yCellCount];
            //set Starting cell;
            StartingCell = Map[0, 0];

            var unclearedTerrain = new TerrainType(1, "uncleared");
            var clearedTerrain = new TerrainType(2, "cleared");
            //Populate Map
            var list = new List<CellState>();
            for (int i = 0; i < _mapHeight; i++)
            {
                for (int j = 0; j < _mapWidth; j++)
                {
                    list.Add(new CellState(false, new Coordinate2D(i, j, OffsetTypes.OddRowsRight), unclearedTerrain));
                }
            }
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
            HexGraph = GraphFactory.CreateRectangularGraph(_mapWidth, _mapHeight, movementTypes, unclearedTerrain);
        }

        public List<GlobalDirection> PossibleMoves(ICell currentCell)
        {
            var x = currentCell.X;
            var y = currentCell.Y;
            var possibles = new List<GlobalDirection>();
            
            if(currentCell.Y != _mapHeight)
                possibles.Add(GlobalDirection.North);
            
            if(currentCell.Y != 0)
                possibles.Add(GlobalDirection.South);
            
            if(currentCell.X != _mapWidth && currentCell.Y != _mapHeight)
                possibles.Add(GlobalDirection.NorthEast);
            return possibles;
        }
    }
}