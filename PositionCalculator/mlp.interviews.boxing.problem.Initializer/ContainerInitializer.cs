using System.Linq;
using mlp.interviews.boxing.problem.Implementation;
using mlp.interviews.boxing.problem.Interface.Interfaces;
using SimpleInjector;

namespace mlp.interviews.boxing.problem.Initializer
{
    public class ContainerInitializer
    {
        public IExecutor GetExecutor()
        {
            var container = new Container();

            var implementationAsembly = typeof(Executor).Assembly;
            var interfaceAssembly = typeof(IExecutor).Assembly;

            var interfaces = interfaceAssembly.GetExportedTypes().Where(t => t.IsInterface).ToArray();
            var instanciables = implementationAsembly.GetExportedTypes().Where(type => !type.IsAbstract && !type.IsInterface);

            var maps = instanciables.Select(type => new
            {
                type,
                @interface = type.GetInterfaces().FirstOrDefault(i => interfaces.Contains(i))
            }).Where(map => map.@interface != null);

            foreach (var map in maps)
            {
                container.Register(map.@interface, map.type);
            }

            return container.GetInstance<IExecutor>();
        }
    }
}