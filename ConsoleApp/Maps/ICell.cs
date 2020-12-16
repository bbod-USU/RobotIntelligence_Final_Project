namespace ConsoleApp.Maps
{
    public interface ICell
    {
        int X { get; }
        int Y { get; }
        Coverage Coverage { get; set; }
    }
}