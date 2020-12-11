namespace ConsoleApp.Maps
{
    public interface ISquareCell : ICell
    {
        new int X { get; }
        new int Y { get; }
    }
}