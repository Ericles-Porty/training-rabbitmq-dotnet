using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ProducerCommands;
public class ProducePurchaseHandler : IRequestHandler<ProducePurchaseCommand, Purchase>
{

    public ProducePurchaseHandler()
    {
    }

    public async Task<Purchase> Handle(ProducePurchaseCommand request, CancellationToken cancellationToken)
    {
        return new Purchase(
            request.ProductId,
            request.Quantity,
            request.Total
        );
    }
}