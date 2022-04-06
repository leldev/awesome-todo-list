namespace Awesome.Todo.Api.Services.MessageBusService.Models;

public class TodoPublishModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsCompleted { get; set; }

    public string Publisher { get; set; }
}
