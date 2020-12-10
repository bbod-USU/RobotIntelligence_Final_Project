namespace ConsoleApp
{
    public class MapFactory : IMapFactory
    {
        private int _defaultHeight;
        private int _defaultWidth;
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public MapFactory()
        {
            _defaultHeight = 0;
            _defaultWidth = 0;
            Height = _defaultHeight;
            Width = _defaultWidth;
        }

        void CreateMaps(int height, int width)
        {
            Height = height;
            Width = width;
        }

        void CreateMaps()
        {
            
        }
    }
}