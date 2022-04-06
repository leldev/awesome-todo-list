using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todo.GetById;

public class QueryRequest : IRequest<IActionResult>
{
    public int Id { get; set; }
}
