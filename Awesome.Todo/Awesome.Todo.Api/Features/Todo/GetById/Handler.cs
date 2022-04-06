using AutoMapper;
using Awesome.Todo.Api.Data;
using Awesome.Todo.Api.Features.Todo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Awesome.Todo.Api.Features.Todo.GetById;

public class Handler : IRequestHandler<QueryRequest, IActionResult>
{
    private readonly AwesomeDbContext context;
    private readonly IMapper mapper;

    public Handler(AwesomeDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(QueryRequest request, CancellationToken cancellationToken)
    {
        var todo = await this.context.Todos.FirstOrDefaultAsync(x => x.Id == request.Id).ConfigureAwait(false);

        if (todo is null)
        {
            return new NotFoundResult();
        }
        else
        {
            return new OkObjectResult(this.mapper.Map<TodoReadModel>(todo));
        }
    }
}
