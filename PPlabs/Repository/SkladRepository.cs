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

        public IEnumerable<Sklad> GetAllSklads(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(p => p.SkladName)
        .ToList();

        public Sklad GetSklad(Guid skladId, bool trackChanges) => 
            FindByCondition(p => p.Id.Equals(skladId), trackChanges).SingleOrDefault();

        public void CreateSklad(Sklad sklad) => Create(sklad);

        public void DeleteSklad(Sklad sklad)
        {
            Delete(sklad);
        }
    }
}
