using System.Security.Cryptography;
using System.Text;
using Eris.Rabbit.Store.Domain.Entities;
using Eris.Rabbit.Store.Domain.Messages.Purchase;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ProducerCommands;
public class ProducePurchaseHandler : IRequestHandler<ProducePurchaseCommand, PurchaseMessage>
{

    public async Task<PurchaseMessage> Handle(ProducePurchaseCommand request, CancellationToken cancellationToken)
    {
        var message = new PurchaseMessage
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Total = request.Total,
            CreatedAt = DateTime.Now
        };
        var json = JsonConvert.SerializeObject(message);

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "admin",
            Password = "123456"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "purchase",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "",
            routingKey: "purchase",
            basicProperties: null,
            body: body);

        return message;
    }
}