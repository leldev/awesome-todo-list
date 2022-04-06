using FluentValidation;

namespace Awesome.Todo.Api.Features.Todos.GetById;

public class Validations : AbstractValidator<QueryRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;

        this.RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Error");
    }
}