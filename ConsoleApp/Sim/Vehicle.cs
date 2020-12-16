using System;
using System.Collections.Generic;
using ConsoleApp.Maps;

namespace ConsoleApp.Sim
{
    public class Vehicle : IVehicle
    {
        public int Length { get; }
        public int Width { get; }
        public int TurnRadius { get; }
        public int DetectorRadius { get;}
        public HexCore.Coordinate2D CurrentHexCell { get; set; }
        public ICell CurrentSquareCell { get; set; }
        
        

        
        public Vehicle(IJsonDeserializor jsonDeserializor)
        {
            var config = jsonDeserializor.DeserializeObject<VehicleConfiguration>("/Users/brady.bodily/Documents/Repositories/CS5890_Robot_Intelligence/RobotIntelFinal/ConsoleApp/Sim/VehicleConfiguration.json");
            var length = config.Length;
            length *= 100;
            Length = (int)Math.Ceiling((decimal)length/ 25);
            var width = config.Width;
            width *= 100;
            Width = (int)Math.Ceiling((decimal)width/ 25);
            DetectorRadius = (int)Math.Floor(((decimal)config.DetectorRadius * 100)/25)/2;
            TurnRadius = (int)Math.Ceiling(Math.Sqrt(Math.Pow(config.Length, 2) * Math.Pow(config.Width, 2))/2);
            // if (DetectorRadius <= TurnRadius)
            //     throw new ArgumentException("Detection radius must be larger than the vehicle turn radius");

        }
    }
}