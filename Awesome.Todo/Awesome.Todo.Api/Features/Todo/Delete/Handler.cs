using AutoMapper;
using Awesome.Todo.Api.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Awesome.Todo.Api.Features.Todo.Delete;

public class Handler : IRequestHandler<CommandRequest, IActionResult>
{
    private readonly AwesomeDbContext context;
    private readonly IMapper mapper;

    public Handler(AwesomeDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
    {
        var todo = await this.context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id).ConfigureAwait(false);

        if (todo is not null)
        {
            this.context.Todos.Remove(todo);
            await this.context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return new NoContentResult();
    }
}
