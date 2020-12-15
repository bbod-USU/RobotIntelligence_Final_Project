using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleApp.Maps
{
    public interface IMapFactory
    {
        int Height { get; }
        int Width { get; }
        int CellWidth { get; }
        void GenerateMaps(int x, int y);
        IHexMap GetHexMap();
        ISquareMap GetSquareMap();
    }
}