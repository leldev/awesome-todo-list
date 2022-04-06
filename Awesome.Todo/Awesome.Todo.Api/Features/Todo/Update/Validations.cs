using FluentValidation;

namespace Awesome.Todo.Api.Features.Todo.Update;

public class Validations : AbstractValidator<CommandRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;

        this.RuleFor(x => x.Body.Name)
            .NotEmpty()
            .WithMessage("Empty")
            .MaximumLength(Domain.Todo.MaxNameLength)
            .WithMessage("Max lenght");
    }
}