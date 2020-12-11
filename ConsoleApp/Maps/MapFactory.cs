using System.Collections.Generic;

namespace ConsoleApp.Maps
{
    public class MapFactory : IMapFactory
    {
        private int _defaultHeight;
        private int _defaultWidth;
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public Dictionary<string, IMap> Maps { get; }


        public void GenerateMaps(int x, int y)
        {
            Width = x;
            Height = y;
            Maps.Add("SquareMap",new SquareMap(x, y));
            Maps.Add("HexMap", new HexMap(x, y));
        }

        public MapFactory()
        {
            _defaultHeight = 0;
            _defaultWidth = 0;
            Height = _defaultHeight;
            Width = _defaultWidth;
            Maps = new Dictionary<string, IMap>();
        }
        
    }
}