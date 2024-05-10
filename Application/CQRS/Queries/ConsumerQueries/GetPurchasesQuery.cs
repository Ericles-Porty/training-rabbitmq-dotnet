using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Queries.ConsumerQueries;

public class GetPurchasesQuery() : IRequest<IEnumerable<Purchase>>
{
}