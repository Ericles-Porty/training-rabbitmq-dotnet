using Eris.Rabbit.Store.Domain.Messages.Purchase;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ProducerCommands;

public class ProducePurchaseCommand : IRequest<PurchaseMessage>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}