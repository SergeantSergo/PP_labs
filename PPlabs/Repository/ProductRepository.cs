using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateProductForSklad(Guid IDSklad, Product product)
        {
            product.IDSklad = IDSklad;
            Create(product);
        }
        public IEnumerable<Product> GetProducts(Guid IDSklad, bool trackChanges) =>
        FindByCondition(e => e.IDSklad.Equals(IDSklad), trackChanges)
        .OrderBy(e => e.NameProduct);

        public Product GetProduct(Guid IDSklad, Guid id, bool trackChanges) => FindByCondition(e => e.IDSklad.Equals(IDSklad) && e.Id.Equals(id), trackChanges).SingleOrDefault();
        public void DeleteProduct(Product product)
        {
            Delete(product);
        }



    }
}
