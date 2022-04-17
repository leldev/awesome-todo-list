using System.ComponentModel.DataAnnotations;

namespace Awesome.Datawarehouse.Api.Domain;

public abstract class Entity<TId>
{
    [Key]
    [Required]
    public TId Id { get; protected internal set; }
}