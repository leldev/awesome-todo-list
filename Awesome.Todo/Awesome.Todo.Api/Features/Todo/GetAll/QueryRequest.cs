using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todo.GetAll;

public class QueryRequest : IRequest<IActionResult>
{
}
