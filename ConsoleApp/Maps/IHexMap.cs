using HexCore;

namespace ConsoleApp.Maps
{
    public interface IHexMap
    {
        Graph Graph { get; }
        OffsetTypes OffsetType { get; }
        int Width { get; }
        int Height { get; }
        MovementType DefaultMovement { get; }
    }
}