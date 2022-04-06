using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todo.Delete;

public class CommandRequest : IRequest<IActionResult>
{
    public int Id { get; set; }
}
