using Awesome.Todo.Api.Features.Todo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todo.Update;

public class CommandRequest : IRequest<IActionResult>
{
    public int Id { get; set; }

    [FromBody]
    public TodoWriteModel Body { get; set; }
}
