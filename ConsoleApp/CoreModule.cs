using ConsoleApp.Maps;
using ConsoleApp.PathPlanners;
using ConsoleApp.Sim;
using DryIoc;

namespace ConsoleApp
{
    public class CoreModule : IModule
    {
        public virtual void Register(IContainer container)
        {
            container.Register<IMapFactory, MapFactory>(Reuse.Singleton);
            container.Register<ISimRunner, SimRunner>(Reuse.Singleton);
            container.Register<IVehicle, Vehicle>(Reuse.Singleton);
            container.Register<IJsonDeserializor, JsonDeserializor>(Reuse.Singleton);
            container.Register<IPathPlanner, PathPlanner>(Reuse.Singleton);
            container.Register<IReactivePathPlanner, ReactivePathPlanner>(Reuse.Singleton);
        }
        

        public virtual void Resolve(IContainer container)
        {
            
        }
    }
}