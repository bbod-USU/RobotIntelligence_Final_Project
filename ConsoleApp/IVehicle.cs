using ConsoleApp.Maps;

namespace ConsoleApp
{
    public interface IVehicle
    {
        int Length { get; }
        int Width { get; }
        int DetectorOffset { get;}
        int DetectorWidth { get;}
        HexCore.Coordinate2D CurrentHexCell { get; set; }
        Heading HexHeading { get; set; }
        Heading SquareHeading { get; set; }
        ICell CurrentSquareCell { get; set; }
    }
}