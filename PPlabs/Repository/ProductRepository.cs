using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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


       
        public async Task<Product> GetProductsAsync(Guid IDSklad, Guid id, bool trackChanges) =>
            await FindByCondition
            (
                e => e.IDSklad.Equals(IDSklad) && e.Id.Equals(id), trackChanges
            ).SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductAsync(Guid IDSklad, bool trackChanges) =>
            await FindByCondition(e => e.IDSklad.Equals(IDSklad), trackChanges).OrderBy(c => c.NameProduct).ToListAsync();
       
        public void DeleteProduct(Product product) => Delete(product);
        
        public void CreateProductForSklad(Guid IDSklad, Product product)
        {
            product.IDSklad = IDSklad;
            Create(product);
        }


    }
}
