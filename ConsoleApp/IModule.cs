using DryIoc;
namespace ConsoleApp
{
    public interface IModule
    {
        void Register(IContainer container);
        void Resolve(IContainer container);
    }
}