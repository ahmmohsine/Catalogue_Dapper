using Catalogue.Core.Entities;
using Catalogue.Core.Interfeces;

namespace Catalogue.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<int> CreateAsync(Product product, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product product, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
