namespace DI;

public class Program
{
    static void Main(string[] args)
    {
        var resolver = new Resolver();

        var greetingsService = resolver.Get<GreetingsService>();
        WrapInComments(greetingsService.Greet);

        greetingsService = resolver.Get<GreetingsService>();
        WrapInComments(greetingsService.Greet);
    }

    private static void WrapInComments(Action func)
    {
        Console.WriteLine("### Start greeting ###");
        func();
        Console.WriteLine("### End greeting ###");
    }
}
