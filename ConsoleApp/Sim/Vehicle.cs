using ConsoleApp.Maps;

namespace ConsoleApp.Sim
{
    public class Vehicle : IVehicle
    {
        public int Length { get; }
        public int Width { get; }

        public int DetectorOffset { get;}
        public int DetectorRadius { get;}
        public HexCore.Coordinate2D CurrentHexCell { get; set; }
        public Heading HexHeading { get; set; }
        public Heading SquareHeading { get; set; }
        public ICell CurrentSquareCell { get; set; }
        
        

        
        public Vehicle(IJsonDeserializor jsonDeserializor)
        {
            var config = jsonDeserializor.DeserializeObject<VehicleConfiguration>("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Sim/VehicleConfiguration.json");
            Length = config.Length;
            Width = config.Width;
            DetectorRadius = config.DetectorRadius;
            DetectorOffset = config.DetectorOffset;
            CurrentHexCell = default;
            CurrentSquareCell = default;
        }
    }
}