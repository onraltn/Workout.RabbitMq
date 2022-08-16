using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Producer;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        DirectExchangePublisher.Publish(channel);

    }
}