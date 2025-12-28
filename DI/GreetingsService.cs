namespace DI;

public class GreetingsService
{
    private readonly PrintService _printService;

    public GreetingsService(PrintService printService)
    {
        _printService = printService;
    }

    public void Greet()
    {
        _printService.Print("Hello, World!");
    }
}