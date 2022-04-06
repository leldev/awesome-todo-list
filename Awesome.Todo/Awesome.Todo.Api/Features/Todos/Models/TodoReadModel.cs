namespace Awesome.Todo.Api.Features.Todos.Models
{
    public class TodoReadModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }
    }
}
