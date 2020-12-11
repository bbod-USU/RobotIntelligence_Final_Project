using System.Threading;
using ConsoleApp.Maps;
using DryIoc;

namespace ConsoleApp
{
    public class CoreModule : IModule
    {
        public virtual void Register(IContainer container)
        {
            container.Register<IMapFactory, MapFactory>(Reuse.Singleton);
            container.Register<ISimRunner, SimRunner>(Reuse.Singleton);
        }
        

        public virtual void Resolve(IContainer container)
        {
            
        }
    }
}