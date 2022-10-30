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

        //public Product GetProduct(Guid productId, bool trackChanges) => FindByCondition(c => c.Id.Equals(productId), trackChanges).SingleOrDefault();
        //не работает
        
        //public IEnumerable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges)
        //.OrderBy(c => c.NameProduct)
        //.ToList();



        //public IEnumerable<Product> GetProduct(Guid countryId, bool trackChanges) =>
        //    FindByCondition(e => e.IDSklad.Equals(countryId), trackChanges).OrderBy(e => e.NameProduct);
        //public Product GetProduct(Guid productId, Guid id, bool trackChanges) =>
        //    FindByCondition(e => e.IDSklad.Equals(productId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
