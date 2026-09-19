using Catalogue.Core.Entities;

namespace Catalogue.Core.Interfeces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(Product product);
    bool DeleteProduct(int id);
}

