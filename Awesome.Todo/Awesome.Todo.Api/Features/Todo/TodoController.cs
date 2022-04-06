using Awesome.Todo.Api.Features.Todo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Awesome.Todo.Api.Features.Todo
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateTodoAsync([FromBody] Create.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet("{Id}", Name = "Todo.GetById")]
        [ProducesResponseType(typeof(TodoReadModel), ((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetById.QueryRequest query)
        {
            return await this.mediator.Send(query).ConfigureAwait(false);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodoReadModel>), ((int)HttpStatusCode.OK))]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAll.QueryRequest query)
        {
            return await this.mediator.Send(query).ConfigureAwait(false);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Delete.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(TodoReadModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<IActionResult> CreateChatAsync([FromRoute] Update.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }
    }
}
