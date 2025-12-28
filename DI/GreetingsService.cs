namespace DI;

public class GreetingsService
{
    private readonly PrintService _printService;
    private readonly HelloService _helloService;
    private readonly Logger _logger;

    public GreetingsService(
        PrintService printService,
        HelloService helloService,
        Logger logger)
    {
        _printService = printService;
        _helloService = helloService;
        _logger = logger;
    }

    public void Greet()
    {
        _logger.Trace(this);

        _printService.Print(_helloService.GetHello());
    }
}