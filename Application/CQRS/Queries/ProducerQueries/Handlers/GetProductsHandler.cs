using Eris.Rabbit.Store.Domain.Entities;
using Eris.Rabbit.Store.Infra.Data.Repositories;
using MediatR;

namespace Eris.Rabbit.Store.Application.CQRS.Queries.ProducerQueries.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly ProductRepository _productRepository;

    public GetProductsHandler(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync();
    }
}