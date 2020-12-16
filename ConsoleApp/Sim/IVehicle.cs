using ConsoleApp.Maps;
using HexCore;

namespace ConsoleApp.Sim
{
    public interface IVehicle
    {
        int Length { get; }
        int Width { get; }
        int TurnRadius { get; }
        int DetectorRadius { get;}
        Coordinate2D CurrentHexCell { get; set; }
        ICell CurrentSquareCell { get; set; }
    }
}