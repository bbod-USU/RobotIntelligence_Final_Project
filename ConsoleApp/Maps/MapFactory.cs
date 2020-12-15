using System;
using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class MapFactory : IMapFactory
    {
        private int _defaultHeight;
        private int _defaultWidth;
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public int CellWidth { get; }
        

        
        private ISquareMap _squareMap;

        private IHexMap _hexMap;

        public void GenerateMaps(int x, int y)
        {
            Width = x;
            Height = y;
            _squareMap = new SquareMap(x, y);
            _hexMap = new HexMap(x, y);
        }
        public IHexMap GetHexMap() => _hexMap ?? throw new NullReferenceException("hex map not initialized");
        public ISquareMap GetSquareMap() => _squareMap ?? throw new NullReferenceException("square map not initialized");

        public MapFactory(IVehicle vehicle)
        {
            CellWidth = vehicle.Width/2;
            _defaultHeight = 0;
            _defaultWidth = 0;
            Height = _defaultHeight;
            Width = _defaultWidth;
            _hexMap = default;
            _squareMap = default;
        }
        
    }
}