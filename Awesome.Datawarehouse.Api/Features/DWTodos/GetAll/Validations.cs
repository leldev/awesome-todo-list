using FluentValidation;

namespace Awesome.Datawarehouse.Api.Features.DWTodos.GetAll;

public class Validations : AbstractValidator<QueryRequest>
{
    public Validations()
    {
        this.CascadeMode = CascadeMode.Stop;
    }
}