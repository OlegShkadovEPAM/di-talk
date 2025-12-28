namespace DI;

public class Container
{
    private readonly Dictionary<Type, Dependency> _collection = [];

    public void AddTransient<T>()
    {
        _collection[typeof(T)] = new Dependency { Scope = Scopes.Transient };
    }

    public void AddScoped<T>()
    {
        _collection[typeof(T)] = new Dependency { Scope = Scopes.Scoped };
    }

    public void AddSingleton<T>()
    {
        _collection[typeof(T)] = new Dependency { Scope = Scopes.Singleton };
    }

    public Dependency Get(Type type)
    {
        return _collection[type];
    }
}
