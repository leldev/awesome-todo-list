using Microsoft.EntityFrameworkCore;

namespace Awesome.Datawarehouse.Api.Data;

public class AwesomeDbContext : DbContext
{
    public AwesomeDbContext(DbContextOptions<AwesomeDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.DWTodo> DWTodos { get; set; }
}