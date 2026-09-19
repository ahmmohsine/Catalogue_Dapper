using Catalogue.Core.Entities;
using Catalogue.Core.Interfeces;

namespace Catalogue.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Product> IProductRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
