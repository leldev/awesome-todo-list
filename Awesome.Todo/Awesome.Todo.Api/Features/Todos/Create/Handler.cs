using AutoMapper;
using Awesome.Todo.Api.Data;
using Awesome.Todo.Api.Features.Todos.Models;
using Awesome.Todo.Api.Services.MessageBusService;
using Awesome.Todo.Api.Services.MessageBusService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Todo.Api.Features.Todos.Create;

public class Handler : IRequestHandler<CommandRequest, IActionResult>
{
    private readonly AwesomeDbContext context;
    private readonly IMapper mapper;
    private readonly IMessageBusClient messageBusClient;

    public Handler(AwesomeDbContext context, IMapper mapper, IMessageBusClient messageBusClient)
    {
        this.context = context;
        this.mapper = mapper;
        this.messageBusClient = messageBusClient;
    }

    public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
    {
        var todo = this.mapper.Map<Domain.Todo>(request);

        context.Todos.Add(todo);
        await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var todoPublisher = this.mapper.Map<TodoPublishModel>(todo);
        this.messageBusClient.PublishTodo(todoPublisher);

        return new CreatedAtRouteResult("Todo.GetById", new { todo.Id }, this.mapper.Map<TodoReadModel>(todo));
    }
}
