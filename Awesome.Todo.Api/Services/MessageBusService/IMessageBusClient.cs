using Awesome.Todo.Api.Services.MessageBusService.Models;

namespace Awesome.Todo.Api.Services.MessageBusService;

public interface IMessageBusClient
{
    void PublishTodo(TodoPublishModel platformPublishedDto);
}