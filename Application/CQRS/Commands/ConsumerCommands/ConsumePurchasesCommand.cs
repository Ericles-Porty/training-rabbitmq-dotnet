using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Commands.ConsumerCommands;

public class ConsumePurchasesCommand : IRequest<List<Purchase>>
{
}