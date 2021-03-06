using System.ComponentModel.DataAnnotations;

namespace Awesome.Todo.Api.Domain;

public abstract class Entity<TId>
{
    [Key]
    [Required]
    public TId Id { get; protected internal set; }
}