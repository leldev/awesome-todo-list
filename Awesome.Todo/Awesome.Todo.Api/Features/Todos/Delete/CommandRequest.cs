using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todos.Delete;

public class CommandRequest : IRequest<IActionResult>
{
    public int Id { get; set; }
}
