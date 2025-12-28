namespace DI;

public class Program
{
    static void Main(string[] args)
    {
        var greetingsService = new GreetingsService();
        greetingsService.Greet();
    }
}
