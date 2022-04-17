using AutoMapper;
using Awesome.Todo.Api.Data;
using Awesome.Todo.Api.Features.Todos.Models;
using Awesome.Todo.Api.Services.MessageBusService;
using Awesome.Todo.Api.Services.MessageBusService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Awesome.Todo.Api.Features.Todos.Update;

public class Handler : IRequestHandler<CommandRequest, IActionResult>
{
    private readonly IConfiguration configuration;
    private readonly AwesomeDbContext context;
    private readonly IMapper mapper;
    private readonly IMessageBusClient messageBusClient;

    public Handler(IConfiguration configuration, AwesomeDbContext context, IMapper mapper, IMessageBusClient messageBusClient)
    {
        this.configuration = configuration;
        this.context = context;
        this.mapper = mapper;
        this.messageBusClient = messageBusClient;
    }

    public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
    {
        var todo = await this.context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id).ConfigureAwait(false);

        if (todo is null)
        {
            return new NotFoundResult();
        }
        else
        {
            this.mapper.Map(request.Body, todo);

            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var todoPublisher = this.mapper.Map<TodoPublishModel>(todo);
            todoPublisher.Publisher = this.configuration["PublisherName"];
            this.messageBusClient.PublishTodo(todoPublisher);

            return new OkObjectResult(this.mapper.Map<TodoReadModel>(todo));
        }
    }
}
