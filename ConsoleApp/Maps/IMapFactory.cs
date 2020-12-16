using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleApp.Maps
{
    public interface IMapFactory
    {
        int Height { get; }
        int Width { get; }
        int CellWidth { get; }
        void GenerateMaps(int x, int y, double minePercentage);
        IHexMap GetHexMap();
        ISquareMap GetSquareMap();
        IMineMap GetMineMap();
    }
}