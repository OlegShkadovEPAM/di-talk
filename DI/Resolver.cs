namespace DI;

public class Resolver
{
    private readonly Container _container;

    public Resolver(Container container)
    {
        _container = container;
    }

    public T Get<T>()
    {
        return (T)GetInternal(typeof(T));
    }

    private object GetInternal(Type type)
    {
        // Check if the parameter is already instantiated
        var dependency = _container.Get(type);
        if (dependency.Instance != null)
        {
            return dependency.Instance;
        }

        var parameters = InstantiateParameters(type);
        var instance = Activator.CreateInstance(type, parameters);

        // Save instance for future use if singleton
        if (dependency.Scope == Scopes.Singleton)
        {
            dependency.Instance = instance;
        }

        return instance;
    }

    private object[] InstantiateParameters(Type type)
    {
        // Get constructor parameters
        var constructor = type.GetConstructors().Single();
        var parameterInfo = constructor.GetParameters();

        // Instantiate the parameters
        var parameters = new object[parameterInfo.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i] = GetInternal(
                parameterInfo[i].ParameterType);
        }

        return parameters;
    }
}