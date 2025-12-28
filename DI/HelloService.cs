namespace DI;

public class HelloService
{
    private readonly WorldService _worldService;
    private readonly Logger _logger;

    public HelloService(WorldService worldService, Logger logger)
    {
        _worldService = worldService;
        _logger = logger;
    }

    public string GetHello()
    {
        _logger.Trace(this);

        return $"Hello, {_worldService.GetWorld()}!";
    }
}
