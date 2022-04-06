using Awesome.Todo.Api.Data;
using Awesome.Todo.Api.Services.MessageBusService;
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

Console.WriteLine($"--> Connection String: {builder.Configuration.GetConnectionString("AwesomeConnectionString")}");

builder.Services.AddDbContext<AwesomeDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AwesomeConnectionString")));
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsDevelopment());

app.Run();
