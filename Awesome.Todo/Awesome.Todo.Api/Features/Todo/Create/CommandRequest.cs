using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todo.Create;

public class CommandRequest : IRequest<IActionResult>
{
    public string Name { get; set; }
}
