using Awesome.Datawarehouse.Api.Services.EventProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Awesome.Datawarehouse.Api.Services.MessageBusService;

public class MessageBusSubscriber : BackgroundService
{
    private readonly IConfiguration configuration;
    private readonly IEventProcessor eventProcessor;
    private IConnection connection;
    private IModel channel;
    private string queueName;

    public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
    {
        this.configuration = configuration;
        this.eventProcessor = eventProcessor;

        this.InitializeMessageBus();
    }

    private void InitializeMessageBus()
    {
        var factory = new ConnectionFactory()
        {
            HostName = this.configuration["RabbitMQHost"],
            Port = int.Parse(this.configuration["RabbitMQPort"])
        };

        this.connection = factory.CreateConnection();
        this.channel = this.connection.CreateModel();
        this.channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        this.queueName = this.channel.QueueDeclare().QueueName;
        this.channel.QueueBind(queue: this.queueName,
            exchange: "trigger",
            routingKey: "");

        Console.WriteLine("--> Listenting on the Message Bus...");

        this.connection.ConnectionShutdown += Connection_ConnectionShutdown;
    }

    private void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine("--> Connection Shutdown");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(this.channel);

        consumer.Received += (ModuleHandle, ea) =>
        {
            Console.WriteLine("--> Event Received.");

            var body = ea.Body;
            var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

            this.eventProcessor.ProcessEvent(notificationMessage);
        };

        this.channel.BasicConsume(queue: this.queueName, autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        if (this.channel.IsOpen)
        {
            this.channel.Close();
            this.connection.Close();
        }

        base.Dispose();
    }
}
