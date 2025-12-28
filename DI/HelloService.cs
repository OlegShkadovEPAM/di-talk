namespace DI;

public class HelloService
{
    private readonly WorldService _worldService;

    public HelloService(WorldService worldService)
    {
        _worldService = worldService;
    }

    public string GetHello()
    {
        return $"Hello, {_worldService.GetWorld()}!";
    }
}
