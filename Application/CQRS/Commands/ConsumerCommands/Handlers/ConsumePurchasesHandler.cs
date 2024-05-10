using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ConsumerCommands.Handlers;

public class ConsumePurchasesHandler : IRequestHandler<ConsumePurchasesCommand, List<Purchase>>
{

    public ConsumePurchasesHandler()
    {
    }

    public async Task<List<Purchase>> Handle(ConsumePurchasesCommand request, CancellationToken cancellationToken)
    {
        return new List<Purchase>();
    }
}