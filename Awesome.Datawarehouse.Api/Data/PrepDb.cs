using Microsoft.EntityFrameworkCore;

namespace Awesome.Datawarehouse.Api.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AwesomeDbContext>());
    }

    private static void SeedData(AwesomeDbContext context)
    {
        context.Database.Migrate();
    }
}