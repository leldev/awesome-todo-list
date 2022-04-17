using Awesome.Datawarehouse.Api.Features.DWTodos.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Awesome.Datawarehouse.Api.Features.DWTodos;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class DWTodosController : Controller
{
    private readonly IMediator mediator;

    public DWTodosController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<DWTodoReadModel>), ((int)HttpStatusCode.OK))]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAll.QueryRequest query)
    {
        return await this.mediator.Send(query).ConfigureAwait(false);
    }
}