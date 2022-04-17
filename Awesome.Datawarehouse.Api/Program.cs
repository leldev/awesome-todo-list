using Awesome.Datawarehouse.Api.Data;
using Awesome.Datawarehouse.Api.Services.EventProcessor;
using Awesome.Datawarehouse.Api.Services.MessageBusService;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();

Console.WriteLine($"--> Connection String: {builder.Configuration.GetConnectionString("AwesomeConnectionString")}");
builder.Services.AddDbContext<AwesomeDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AwesomeConnectionString")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();