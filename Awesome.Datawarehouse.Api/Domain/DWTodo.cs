using System.ComponentModel.DataAnnotations;

namespace Awesome.Datawarehouse.Api.Domain;

public class DWTodo : Entity<int>
{
    public DWTodo()
    {
        this.Name = string.Empty;
    }

    [Required]
    public string Name { get; set; }

    [Required]
    public string ExternalId { get; set; }

    [Required]
    public string Publisher { get; set; }

    public bool IsCompleted { get; private set; }
}