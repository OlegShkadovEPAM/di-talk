namespace DI;

public class Resolver
{
    public T Get<T>()
    {
        return (T)GetInternal(typeof(T));
    }

    private static object GetInternal(Type type)
    {
        var parameters = InstantiateParameters(type);

        return Activator.CreateInstance(type, parameters);
    }

    private static object[] InstantiateParameters(Type type)
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