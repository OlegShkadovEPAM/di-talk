namespace DI;

public class Program
{
    static void Main(string[] args)
    {
        // Add services to the DI container
        var container = new Container();
        container.AddTransient<GreetingsService>();
        container.AddTransient<PrintService>();
        container.AddTransient<HelloService>();
        container.AddTransient<WorldService>();

        container.AddSingleton<Logger>();

        var resolver = new Resolver(container);

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
