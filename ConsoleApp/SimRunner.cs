namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;

        public SimRunner(IMapFactory mapFactory)
        {
            _mapFactory = mapFactory;
        }
        public void GenerateMaps(int x, int y)
        {
            _mapFactory.GenerateMaps(x, y);
            _mapFactory.SquareMap();
            throw new System.NotImplementedException();
        }

        public void StartSim()
        {
            throw new System.NotImplementedException();
        }
    }
}