using FluentValidation;

namespace Awesome.Todo.Api.Features.Todo.GetAll;

public class Validations : AbstractValidator<QueryRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;
    }
}