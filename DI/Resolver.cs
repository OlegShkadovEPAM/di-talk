namespace DI;

public class Resolver
{
    public T Get<T>()
    {
        // Get constructor parameter
        var constructor = typeof(T).GetConstructors().Single();
        var parameterInfo = constructor.GetParameters();

        // Instantiate the parameter
        var parameter = Activator.CreateInstance(parameterInfo[0].ParameterType);
        var parameters = new object[]{parameter};

        return (T)Activator.CreateInstance(typeof(T), parameters);
    }
}