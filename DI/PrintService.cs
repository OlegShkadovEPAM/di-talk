namespace DI;

public class PrintService
{
    private readonly Logger _logger;

    public PrintService(Logger logger)
    {
        _logger = logger;
    }

    public void Print(string message)
    {
        _logger.Trace(this);

        Console.WriteLine(message);
    }
}
