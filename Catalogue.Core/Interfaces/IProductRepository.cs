using Catalogue.Core.Entities;

namespace Catalogue.Core.Interfeces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken token = default);
    Task<Product> GetByIdAsync(int id, CancellationToken token = default);
    Task<int> CreateAsync(Product product, CancellationToken token = default);
    Task<bool> UpdateAsync(Product product, CancellationToken token = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

