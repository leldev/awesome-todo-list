using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todos.GetAll;

public class QueryRequest : IRequest<IActionResult>
{
}
