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
    internal class SkladRepository : RepositoryBase<Sklad>, ISkladRepository
    {
        public SkladRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromSkladRepository()
        {
            throw new NotImplementedException();
        }
    }
}
