using Catalogue.Core.Dtos.Product;

namespace Catalogue.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ReadOnlyProductDTO>?> GetAllAsync(CancellationToken token);
        Task<bool> DeleteAsync(int id, CancellationToken token = default);
        Task<bool> UpdateAsync(int id, UpdateProductDTO updateProduct, CancellationToken token);
        Task<ReadOnlyProductDTO?> GetByIdAsync(int id, CancellationToken token);
        Task<int> CreateAsync(CreateProductDTO createProduct, CancellationToken cancellationToken);

    }
}
