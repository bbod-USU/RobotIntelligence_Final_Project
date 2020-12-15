using System;
using ConsoleApp.Maps;

namespace ConsoleApp
{
    public class Vehicle : IVehicle
    {
        public int Length { get; }
        public int Width { get; }

        public int DetectorOffset { get;}
        public int DetectorWidth { get;}
        public HexCore.Coordinate2D CurrentHexCell { get; set; }
        public Heading HexHeading { get; set; }
        public Heading SquareHeading { get; set; }
        public ICell CurrentSquareCell { get; set; }
        

        
        public Vehicle(IJsonDeserializor jsonDeserializor)
        {
            var config = jsonDeserializor.DeserializeObject<VehicleConfiguration>("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/VehicleConfiguration.json");
            Length = config.Length;
            Width = config.Width;
            DetectorWidth = config.DetectorWidth;
            DetectorOffset = config.DetectorOffset;
            CurrentHexCell = default;
            CurrentSquareCell = default;
            HexHeading = default;
            SquareHeading = default;
        }
    }
}