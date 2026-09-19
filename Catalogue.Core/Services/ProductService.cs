using Catalogue.Core.Dtos.Product;

namespace Catalogue.Core.Services
{
    public class ProductService : IProductService
    {
        public Task<int> CreateAsync(CreateProductDTO createProduct, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadOnlyProductDTO>?> GetAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyProductDTO?> GetByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateProductDTO updateProduct, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
