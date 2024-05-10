using Eris.Rabbit.Store.Domain.Entities;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Queries.ConsumerQueries;

public class GetPurchasesHandler : IRequestHandler<GetPurchasesQuery, IEnumerable<Purchase>>
{
    public GetPurchasesHandler()
    {
    }

    public async Task<IEnumerable<Purchase>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
    {
        return new List<Purchase>();
    }
}