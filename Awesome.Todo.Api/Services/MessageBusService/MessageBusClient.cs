using Awesome.Todo.Api.Services.MessageBusService.Models;
using RabbitMQ.Client;

namespace Awesome.Todo.Api.Services.MessageBusService;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration configuration;
    private readonly IConnection connection;
    private readonly IModel channel;

    public MessageBusClient(IConfiguration configuration)
    {
        this.configuration = configuration;

        Console.WriteLine("--> RabbitMQ Connecting...");

        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMQHost"],
            Port = int.Parse(configuration["RabbitMQPort"])
        };

        this.connection = factory.CreateConnection();
        this.channel = this.connection.CreateModel();

        channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

        connection.ConnectionShutdown += Connection_ConnectionShutdown;
    }
    public void PublishTodo(TodoPublishModel platformPublishedDto)
    {
        var message = JsonSerializer.Serialize(platformPublishedDto);

        if (this.connection.IsOpen)
        {
            Console.WriteLine("--> RabbitMQ is open, publishing message...");
            SendMessage(message);
        }
        else
        {
            Console.WriteLine("--> RabbitMQ is closed, could not sent message.");
        }
    }

    public void Dispose()
    {
        Console.WriteLine("MessageBus Disposed");
        if (this.channel.IsOpen)
        {
            this.channel.Close();
            this.connection.Close();
        }
    }

    private void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        this.channel.BasicPublish(exchange: "trigger",
                        routingKey: "",
                        basicProperties: null,
                        body: body);
    }

    private void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine("--> RabbitMQ Connection Shutdown.");
    }
}