using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(Guid IDSKlad, bool trackChanges);
        //Product GetProduct(Guid productId, Guid id, bool trackChanges);

        //void CreateProduct(Guid IDSklad, Product product);
        Product GetProduct(Guid IDSklad, Guid id, bool trackChanges);
        void CreateProductForSklad(Guid IDSklad, Product product);
        void DeleteProduct(Product product);
    }
}
