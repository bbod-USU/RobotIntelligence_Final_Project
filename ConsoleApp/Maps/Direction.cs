using System;

namespace ConsoleApp.Maps
{
    public class Direction
    {
        public static Tuple<int, int> Forward => _forward;
        public static Tuple<int, int> Reverse => _reverse;

        
        private static Tuple<int,int> _forward = new Tuple<int, int>(1, 0);
        private static Tuple<int,int> _reverse = new Tuple<int, int>(-1, 0);

    }
}