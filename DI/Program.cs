namespace DI;

public class Program
{
    static void Main(string[] args)
    {
        //var greetingsService = new GreetingsService();
        var resolver = new Resolver();
        var greetingsService = resolver.Get<GreetingsService>();

        greetingsService.Greet();
    }
}
