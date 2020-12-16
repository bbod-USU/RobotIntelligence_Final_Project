namespace ConsoleApp.Maps
{
    public interface IMineMap
    {
        bool[,] Map { get; }
        
        int TotalBombs { get; }
        bool GetCell(int x, int y);
    }
}