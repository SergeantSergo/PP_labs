using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {
        public PlanRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
        }
        //public IEnumerable<Plan> GetPlans(Guid productid, bool trackChanges) =>
        //    FindByCondition(e => e.Product.Equals(productid), trackChanges).OrderBy(e => e.Id);
        //public Plan GetPlan(Guid productid, Guid id, bool trackChanges) =>
        //    FindByCondition(e => e.Product.Equals(productid) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public async Task<Plan> GetPlanAsync(Guid productId, Guid id, bool trackChanges) =>
            await FindByCondition
            (
                e => e.Product.Equals(productId) && e.Id.Equals(id), trackChanges
            ).SingleOrDefaultAsync();

        public async Task<IEnumerable<Plan>> GetPlansAsync(Guid IDSklad, bool trackChanges) =>
            await FindByCondition(e => e.Sklad1.Equals(IDSklad), trackChanges).OrderBy(c => c.Name).ToListAsync();

        public void CreatePlan(Guid IDSklad,Guid IDSklad2, Guid productId, Plan plan)
        {
            plan.Sklad1 = IDSklad;
            plan.Sklad2 = IDSklad2;
            plan.Product = productId;
            Create(plan);
        }
        public void DeletePlan(Plan plan) => Delete(plan);

        public void DeletePlan(Task<Plan> planForproduct)
        {
            throw new NotImplementedException();
        }
    }
}
