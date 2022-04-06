using Microsoft.EntityFrameworkCore;

namespace Awesome.Todo.Api.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isDevelopment)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AwesomeDbContext>(), isDevelopment);
        }

        private static void SeedData(AwesomeDbContext context, bool isDevelopment)
        {
            if (isDevelopment)
            {
                Console.WriteLine("--> Seeding data...");

                context.Database.EnsureDeleted();
                context.Database.Migrate();

                context.Todos.AddRange(
                    new Domain.Todo() { Name = "Learn .NET 6" },
                    new Domain.Todo() { Name = "Learn C# 10"  },
                    new Domain.Todo() { Name = "Learn Docker" },
                    new Domain.Todo() { Name = "Learn K8S" }
                );

                context.SaveChanges();
            }
            else
            {
                context.Database.Migrate();
            }
        }
    }
}
