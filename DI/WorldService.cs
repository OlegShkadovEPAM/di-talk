namespace DI;

public class WorldService
{
    private readonly Logger _logger;

    public WorldService(Logger logger)
    {
        _logger = logger;
    }

    public string GetWorld()
    {
        _logger.Trace(this);

        return "World";
    }
}
