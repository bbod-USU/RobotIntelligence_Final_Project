using System.Net.NetworkInformation;

namespace ConsoleApp.Maps
{
    public class Oreientation
    {
        public static (int, int) Forward = (0, 1);
        public static (int, int) Backward = (0, -1);
        public static (int, int) Left = (-1, 0);
        public static (int, int) Right = (1, 0);
        public static (int, int) LeftBack = (-1, -1);
        public static (int, int) LeftForward = (-1, 1);
        public static (int, int) RightBack = (1, -1);
        public static (int, int) RightForward = (1, 1);
    }
    public class Heading
    {
        private (int, int) _currentHeading;
        public (int, int) CurrentHeading { get; }

        
        public void SetHeading((int,int)frontAxel, (int,int)backAxel)
        {
            var x = frontAxel.Item1 - backAxel.Item1;
            var y = frontAxel.Item2 - backAxel.Item2;
            //forward
            if (x == 0 && y >= 1) _currentHeading = Oreientation.Forward;
            //backward
            if (x == 0 && y <= -1) _currentHeading = Oreientation.Backward;
            //right
            if (x >= 1 && y == 0) _currentHeading = Oreientation.Right;
            //left
            if (x <= -1 && y == 0) _currentHeading = Oreientation.Left;
            //left, back
            if (x <= -1 && y <= -1) _currentHeading = Oreientation.LeftBack;
            //right, forward
            if (x >= 1 && y >= 1) _currentHeading = Oreientation.RightForward;
            //left, forward
            if (x <= -1 && y >= 1) _currentHeading = Oreientation.LeftForward;
            //right, back
            if (x >= 1 && y <= -1) _currentHeading = Oreientation.RightBack;

        }
        public Heading()
        {
            _currentHeading = Oreientation.Forward;
            CurrentHeading = _currentHeading;
        }


    }
}