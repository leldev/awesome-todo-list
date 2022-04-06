namespace Awesome.Todo.Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected internal set; }
}
