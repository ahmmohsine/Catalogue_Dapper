namespace Catalogue.Core.Services;

using Catalogue.Core.Dtos.Product;
using Catalogue.Core.Entities;
using Catalogue.Core.Interfeces;
using Catalogue.Core.Services.Mappings;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<int> CreateAsync(CreateProductDTO createProduct, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(createProduct);

        Product productEntity = createProduct.ToEntity();
        return await _productRepository.CreateAsync(productEntity, cancellationToken);
    }

    public async Task<IEnumerable<ReadOnlyProductDTO>> GetAllAsync(CancellationToken token = default)
    {
        IEnumerable<Product> products = await _productRepository.GetAllAsync(token);

        return products.ToReadOnlyDtoList();
    }

    public async Task<ReadOnlyProductDTO?> GetByIdAsync(int id, CancellationToken token = default)
    {
        if (id <= 0) return null;

        Product? product = await _productRepository.GetByIdAsync(id, token);

        // SÉCURITÉ : Null-propagation operator (?.) pour éviter le crash NullReferenceException
        return product?.ToReadOnlyDto();
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDTO updateProduct, CancellationToken token = default)
    {
        if (id <= 0) return false;
        ArgumentNullException.ThrowIfNull(updateProduct);

        Product productToUpdate = updateProduct.ToEntity(id);
        return await _productRepository.UpdateAsync(productToUpdate, token);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        if (id <= 0) return false;

        return await _productRepository.DeleteAsync(id, token);
    }
}