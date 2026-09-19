using Catalogue.Core.Dtos.Product;

namespace Catalogue.Core.Services
{
    public interface IProductService
    {
        IEnumerable<ReadOnlyProductDTO> GetAll();
        ReadOnlyProductDTO GetById(int id);
        ReadOnlyProductDTO AddProduct(UpdateProductDto product);
        ReadOnlyProductDTO UpdateProduct(UpdateProductDto product);
        bool DeleteProduct(int id);

    }
}
