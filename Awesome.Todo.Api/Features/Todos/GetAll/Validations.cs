using FluentValidation;

namespace Awesome.Todo.Api.Features.Todos.GetAll;

public class Validations : AbstractValidator<QueryRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;
    }
}