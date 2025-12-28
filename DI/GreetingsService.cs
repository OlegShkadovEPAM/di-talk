namespace DI;

public class GreetingsService
{
    private readonly PrintService _printService;
    private readonly HelloService _helloService;

    public GreetingsService(PrintService printService, HelloService helloService)
    {
        _printService = printService;
        _helloService = helloService;
    }

    public void Greet()
    {
        _printService.Print(_helloService.GetHello());
    }
}