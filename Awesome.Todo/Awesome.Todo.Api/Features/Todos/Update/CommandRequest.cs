using Awesome.Todo.Api.Features.Todos.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todos.Update;

public class CommandRequest : IRequest<IActionResult>
{
    public int Id { get; set; }

    [FromBody]
    public TodoWriteModel Body { get; set; }
}
