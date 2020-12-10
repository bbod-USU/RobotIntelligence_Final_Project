using ConsoleApp.Maps;

namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;

        public SimRunner(IMapFactory mapFactory)
        {
            _mapFactory = mapFactory;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}