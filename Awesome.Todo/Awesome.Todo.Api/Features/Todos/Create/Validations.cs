using FluentValidation;

namespace Awesome.Todo.Api.Features.Todos.Create;

public class Validations : AbstractValidator<CommandRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;

        this.RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Empty")
            .MaximumLength(Domain.Todo.MaxNameLength)
            .WithMessage("Max lenght");
    }
}