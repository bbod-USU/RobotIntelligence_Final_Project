using System;
using System.Collections.Generic;
using ConsoleApp.Sim;

namespace ConsoleApp.Maps
{
    public class MapFactory : IMapFactory
    {
        private int _defaultHeight;
        private int _defaultWidth;
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        

        
        private ISquareMap _squareMap;

        private IHexMap _hexMap;
        
        private IMineMap _mineMap;

        public void GenerateMaps(int x, int y, double minePercentage)
        {
            //convert to cm
            x *= 100;
            y *= 100;
            //calculate number of cells on x and y axis
            var xCellCount = (int)Math.Ceiling((decimal) (x) / 25);
            var yCellCount = (int)Math.Ceiling((decimal) (y) / 25);
            Width = xCellCount;
            Height = yCellCount;
            _squareMap = new SquareMap(xCellCount, yCellCount);
            _hexMap = new HexMap(xCellCount, yCellCount);
            _mineMap = new MineMap(xCellCount, yCellCount, minePercentage);
        }
        public IHexMap GetHexMap() => _hexMap ?? throw new NullReferenceException("hex map not initialized");
        public ISquareMap GetSquareMap() => _squareMap ?? throw new NullReferenceException("square map not initialized");
        public IMineMap GetMineMap() => _mineMap ?? throw new NullReferenceException("mine map not initialized");

        public MapFactory(IVehicle vehicle)
        {
            _defaultHeight = 0;
            _defaultWidth = 0;
            Height = _defaultHeight;
            Width = _defaultWidth;
            _hexMap = default;
            _squareMap = default;
        }
        
    }
}