using MediatR;
using Eris.Rabbit.Store.Domain.Entities;

namespace Eris.Rabbit.Store.Application.CQRS.Queries.ProducerQueries;

public class GetProductsQuery() : IRequest<IEnumerable<Product>>
{
}