using AutoMapper;
using Awesome.Datawarehouse.Api.Data;
using Awesome.Datawarehouse.Api.Services.Models;
using System.Text.Json;

namespace Awesome.Datawarehouse.Api.Services.EventProcessor;

public class EventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory serviceScopeFactory;
    private readonly IMapper mapper;

    public EventProcessor(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
    {
        this.serviceScopeFactory = serviceScopeFactory;
        this.mapper = mapper;
    }

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);

        switch (eventType)
        {
            case EventType.TodoPublished:
                AddTodo(message);
                break;
            default:
                break;
        }
    }

    private void AddTodo(string message)
    {
        using var scope = this.serviceScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AwesomeDbContext>();

        var dwTodoWriteModel = JsonSerializer.Deserialize<DWTodoWriteModel>(message);

        try
        {
            var newTodo = this.mapper.Map<Domain.DWTodo>(dwTodoWriteModel);
            // TODO: AutoMapper is not working
            newTodo.Name = dwTodoWriteModel.Name;
            newTodo.ExternalId = dwTodoWriteModel.Id.ToString();

            if (context.DWTodos.Any(x => x.ExternalId == dwTodoWriteModel.Id.ToString()))
            {
                Console.WriteLine("--> Todo already exisits...");
            }
            else
            {
                Console.WriteLine("--> Todo added.");
                context.DWTodos.Add(newTodo);
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not add Todo to tb {ex.Message}");
        }
    }

    private EventType DetermineEvent(string notifcationMessage)
    {
        Console.WriteLine("--> Determining Event");

        var eventType = JsonSerializer.Deserialize<GenericEventModel>(notifcationMessage);

        if (eventType.Publisher.Contains("Awesome.Todo"))
        {
            Console.WriteLine("--> Todo Published Event Detected");
            return EventType.TodoPublished;
        }

        Console.WriteLine("--> Could not determine the event type");
        return EventType.Undefined;
    }
}
