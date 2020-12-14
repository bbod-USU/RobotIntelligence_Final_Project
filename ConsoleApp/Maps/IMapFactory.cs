using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleApp.Maps
{
    public interface IMapFactory
    {
        int Height { get; }
        int Width { get; }
        int CellWidth { get; }
        Dictionary<string, IMap> Maps { get; }
        void GenerateMaps(int x, int y);
    }
}