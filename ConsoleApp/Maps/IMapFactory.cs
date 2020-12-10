using System.Dynamic;

namespace ConsoleApp
{
    public interface IMapFactory
    {
        int Height { get; }
        int Width { get; }
        SquareMap SquareMap { get; }
        void GenerateMaps(int x, int y);
    }
}