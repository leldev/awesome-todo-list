namespace Awesome.Datawarehouse.Api.Features.DWTodos.Models
{
    public class DWTodoReadModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ExternalId { get; set; }

        public string Publisher { get; set; }

        public bool IsCompleted { get; private set; }
    }
}
