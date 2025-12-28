namespace DI;

public class Resolver
{
    public T Get<T>()
    {
        // Get constructor parameters
        var constructor = typeof(T).GetConstructors().Single();
        var parameterInfo = constructor.GetParameters();

        // Instantiate the parameters
        var parameters = new object[parameterInfo.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i] = Activator.CreateInstance(
                parameterInfo[i].ParameterType);
        }

        return (T)Activator.CreateInstance(typeof(T), parameters);
    }
}