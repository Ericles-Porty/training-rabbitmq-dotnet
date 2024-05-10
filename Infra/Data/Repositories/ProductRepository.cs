using Eris.Rabbit.Store.Domain.Entities;
using Eris.Rabbit.Store.Infra.Data.Contexts;

namespace Eris.Rabbit.Store.Infra.Data.Repositories;

public class ProductRepository(ErisStoreDbContext dbContext) : BaseRepository<Product, int>(dbContext)
{
    private readonly ErisStoreDbContext _dbContext = dbContext;

}