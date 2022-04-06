using System.ComponentModel.DataAnnotations;

namespace Awesome.Todo.Api.Domain;

public class Todo
{
    public static int MaxNameLength => 35;

    public Todo()
    {
        this.Name = string.Empty;
    }

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public bool IsCompleted { get; private set; }

    public void SetComplete()
    {
        this.IsCompleted = true;
    }
}