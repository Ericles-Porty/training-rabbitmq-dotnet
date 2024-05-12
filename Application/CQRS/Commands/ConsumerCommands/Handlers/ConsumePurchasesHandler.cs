using System.Text;
using Eris.Rabbit.Store.Domain.Entities;
using Eris.Rabbit.Store.Domain.Messages.Purchase;
using Eris.Rabbit.Store.Infra.Data.Repositories;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ConsumerCommands.Handlers;

public class ConsumePurchasesHandler : IRequestHandler<ConsumePurchasesCommand, List<Purchase>>
{
    private readonly PurchaseRepository _purchaseRepository;

    public ConsumePurchasesHandler(PurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<List<Purchase>> Handle(ConsumePurchasesCommand request, CancellationToken cancellationToken)
    {
        var purchases = new List<Purchase>();
        var purchaseMessages = new List<PurchaseMessage>();

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
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            var purchaseMessage = JsonConvert.DeserializeObject<PurchaseMessage>(json);
            if (purchaseMessage != null)
            {
                var purchase = new Purchase
                {
                    ProductId = purchaseMessage.ProductId,
                    Quantity = purchaseMessage.Quantity,
                    Total = purchaseMessage.Total
                };
                purchases.Add(purchase);
                purchaseMessages.Add(purchaseMessage);
                await _purchaseRepository.CreateAsync(purchase);
            }

            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        channel.BasicConsume(queue: "purchase",
            autoAck: false,
            consumer: consumer);

        await Task.Delay(10000);

        return purchases;
    }
}