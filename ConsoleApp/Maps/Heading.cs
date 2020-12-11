namespace ConsoleApp.Maps
{
    public class Heading
    {
        private (int, int) _currentHeading;
        public (int, int) CurrentHeading { get; }
        
        public void SetHeading((int,int)frontAxel, (int,int)backAxel)
        {
            var x = frontAxel.Item1 - backAxel.Item1;
            var y = frontAxel.Item2 - backAxel.Item2;
            //forward
            if (x == 0 && y >= 1) _currentHeading = (0, 1);
            //backward
            if (x == 0 && y <= -1) _currentHeading = (0, -1);
            //right
            if (x >= 1 && y == 0) _currentHeading = (1, 0);
            //left
            if (x <= -1 && y == 0) _currentHeading = (-1, 0);
            //left, back
            if (x <= -1 && y <= -1) _currentHeading = (-1, -1);
            //right, forward
            if (x >= 1 && y >= 1) _currentHeading = (1, 1);
            //left, forward
            if (x <= -1 && y >= 1) _currentHeading = (-1, 1);
            //right, back
            if (x >= 1 && y <= -1) _currentHeading = (1, -1);

        }
        public Heading()
        {
            _currentHeading = (1,0);
            CurrentHeading = _currentHeading;
        }


    }
}