using System.Threading;
using ConsoleApp;
using DryIoc;
using Module = ConsoleApp.Module;

namespace Final
{
    public class CoreModule : Module
    {
        public virtual void Register(IContainer container, ExecutionContext executionContext)
        {
            //container.Register<IUserConsole, UserConsole>(Reuse.Singleton);
        }

        public virtual void Resolve(IContainer container)
        {
            
        }
    }
}