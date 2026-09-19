using Catalogue.DTO.Product;

namespace Catalogue.Service
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
