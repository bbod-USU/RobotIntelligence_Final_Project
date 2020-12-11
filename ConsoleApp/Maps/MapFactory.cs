namespace ConsoleApp.Maps
{
    public class MapFactory : IMapFactory
    {
        private int _defaultHeight;
        private int _defaultWidth;
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public SquareMap SquareMap { get; }
        public HexMap HexMap { get; }
        
        
        public void GenerateMaps(int x, int y)
        {
            Width = x;
            Height = y;
            new SquareMap(x, y);
        }

        public MapFactory()
        {
            _defaultHeight = 0;
            _defaultWidth = 0;
            Height = _defaultHeight;
            Width = _defaultWidth;
        }
        
    }
}