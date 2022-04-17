namespace Awesome.Datawarehouse.Api.Services.Models;

public class DWTodoWriteModel : GenericEventModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ExternalId { get; set; }

    public bool IsCompleted { get; private set; }
}
