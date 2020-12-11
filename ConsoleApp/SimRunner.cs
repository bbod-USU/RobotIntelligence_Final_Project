using ConsoleApp.Maps;

namespace ConsoleApp
{
    public class SimRunner : ISimRunner
    {
        private IMapFactory _mapFactory;

        public SimRunner(IMapFactory mapFactory, IVehicle vehicle)
        {
            _mapFactory = mapFactory;
        }

        public void Run()
        {
            
        }
    }
}