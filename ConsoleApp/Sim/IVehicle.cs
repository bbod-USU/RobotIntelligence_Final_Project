using ConsoleApp.Maps;

namespace ConsoleApp.Sim
{
    public interface IVehicle
    {
        int Length { get; }
        int Width { get; }
        int DetectorOffset { get;}
        int DetectorRadius { get;}
        HexCore.Coordinate2D CurrentHexCell { get; set; }
        Heading HexHeading { get; set; }
        Heading SquareHeading { get; set; }
        ICell CurrentSquareCell { get; set; }
    }
}