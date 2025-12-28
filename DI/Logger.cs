namespace DI;

public class Logger
{
    public void Trace(object obj)
    {
        Console.WriteLine($"\t{this.ToString()} #{this.GetHashCode()} in \t{obj.ToString()} #{obj.GetHashCode()}");
    }
}
