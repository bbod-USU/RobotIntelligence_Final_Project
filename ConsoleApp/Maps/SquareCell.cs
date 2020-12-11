namespace ConsoleApp.Maps
{
    public struct SquareCell : ISquareCell
    {
        public int X { get; }
        public int Y { get; }

        public SquareCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}