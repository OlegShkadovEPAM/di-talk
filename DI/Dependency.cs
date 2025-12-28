namespace DI;

public class Dependency
{
    public object? Instance { get; set; }
    public Scopes Scope{ get; set; }
}

public enum Scopes
{
    Transient,
    Singleton,
    Scoped,
}