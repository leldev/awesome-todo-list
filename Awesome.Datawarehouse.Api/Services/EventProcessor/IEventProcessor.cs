namespace Awesome.Datawarehouse.Api.Services.EventProcessor;

public interface IEventProcessor
{
    void ProcessEvent(string message);
}