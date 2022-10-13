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

        public void AnyMethodFromProductRepository()
        {
            throw new NotImplementedException();
        }
    }
}
