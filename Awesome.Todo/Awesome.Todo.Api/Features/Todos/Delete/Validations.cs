using FluentValidation;

namespace Awesome.Todo.Api.Features.Todos.Delete;

public class Validations : AbstractValidator<CommandRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;

        this.RuleFor(x => x.Id)
           .GreaterThan(0)
           .WithMessage("Error");
    }
}