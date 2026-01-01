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
        var instance = (T)GetInternal(typeof(T));

        // Step 5: reset scoped
        _container.ResetScoped();

        return instance;
    }

    private object GetInternal(Type type)
    {
        // Step 1: check if the parameter is already instantiated
        var dependency = _container.Get(type);
        if (dependency.Instance != null)
        {
            return dependency.Instance;
        }

        // Step 2: get parameters 
        var parameters = InstantiateParameters(type);

        // Step 3: create instance
        var instance = Activator.CreateInstance(type, parameters);

        // Step 4: save instance for future use if singleton or scoped
        if (dependency.Scope != Scopes.Transient)
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