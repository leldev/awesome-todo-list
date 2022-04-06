using Microsoft.EntityFrameworkCore;

namespace Awesome.Todo.Api.Data;

public class AwesomeDbContext : DbContext
{
    public AwesomeDbContext(DbContextOptions<AwesomeDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Todo> Todos { get; set; }
}
