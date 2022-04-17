using System.ComponentModel.DataAnnotations;

namespace Awesome.Todo.Api.Domain;

public class Todo : Entity<int>
{
    public static int MaxNameLength => 35;

    public Todo()
    {
        this.Name = string.Empty;
    }

    [Required]
    public string Name { get; set; }

    public bool IsCompleted { get; private set; }

    public void SetComplete()
    {
        this.IsCompleted = true;
    }
}