using AutoMapper;
using Awesome.Datawarehouse.Api.Data;
using Awesome.Datawarehouse.Api.Features.DWTodos.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Awesome.Datawarehouse.Api.Features.DWTodos.GetAll;

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
        var todos = await this.context.DWTodos.ToListAsync(cancellationToken).ConfigureAwait(false);

        return new OkObjectResult(this.mapper.Map<List<DWTodoReadModel>>(todos));
    }
}