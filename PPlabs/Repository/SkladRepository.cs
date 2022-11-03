using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    internal class SkladRepository : RepositoryBase<Sklad>, ISkladRepository
    {
        public SkladRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }



        //public IEnumerable<Sklad> GetAllSklads(bool trackChanges) => FindAll(trackChanges)
        //.OrderBy(p => p.SkladName)
        //.ToList();

        //public Sklad GetSklad(Guid skladId, bool trackChanges) => 
        //    FindByCondition(p => p.Id.Equals(skladId), trackChanges).SingleOrDefault();

        public async Task<Sklad> GetSkladAsync(Guid IDSklad, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(IDSklad), trackChanges).SingleOrDefaultAsync();
        public async Task<IEnumerable<Sklad>> GetAllSkladsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.SkladName).ToListAsync();
        public async Task<IEnumerable<Sklad>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();


        public void CreateSklad(Sklad sklad) => Create(sklad);
        public void DeleteSklad(Sklad sklad) => Delete(sklad);
        
    }
}
