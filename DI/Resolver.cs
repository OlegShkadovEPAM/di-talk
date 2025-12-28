
namespace DI;

public class Resolver
{
    public T Get<T>()
    {
        return (T)Activator.CreateInstance(typeof(T));
    }
}