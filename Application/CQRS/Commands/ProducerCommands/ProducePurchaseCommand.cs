using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ProducerCommands;

public class ProducePurchaseCommand : IRequest<Purchase>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}