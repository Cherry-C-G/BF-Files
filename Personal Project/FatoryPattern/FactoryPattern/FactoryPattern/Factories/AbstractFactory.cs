using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace FactoryPattern.Factories;

    public static void AddAbstractFactory<TInterface,TImplementation>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        services.AddTransient<TInterface, TImplementation>();
        services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
        services.AddSingleton<IAbstractFactory<TInterface>, AbstractFactory<TInterface>>();
    }
    public class AbstractFactory<T>: IAbstractFactory<T>
    {
       
    }
    public interface IAbstractFactory<T>
    {

    }

