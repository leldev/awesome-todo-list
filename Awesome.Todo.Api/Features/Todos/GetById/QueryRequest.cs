using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todos.GetById;

public class QueryRequest : IRequest<IActionResult>
{
    public int Id { get; set; }
}
