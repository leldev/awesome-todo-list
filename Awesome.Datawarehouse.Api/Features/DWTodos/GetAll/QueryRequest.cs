using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Datawarehouse.Api.Features.DWTodos.GetAll
{
    public class QueryRequest : IRequest<IActionResult>
    {
    }
}
