using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {
        public PlanRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
        }

        public IEnumerable<Plan> GetAllPlan(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(c => c.Id)
        .ToList();
    }
}
