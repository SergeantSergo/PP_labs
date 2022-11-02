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
        public IEnumerable<Plan> GetPlans(Guid productid, bool trackChanges) =>
            FindByCondition(e => e.Product.Equals(productid), trackChanges).OrderBy(e => e.Id);
        public Plan GetPlan(Guid productid, Guid id, bool trackChanges) =>
            FindByCondition(e => e.Product.Equals(productid) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public void CreatePlan(Guid IDSklad,Guid IDSklad2, Guid productId, Plan plan)
        {
            plan.Sklad1 = IDSklad;
            plan.Sklad2 = IDSklad2;
            plan.Product = productId;
            Create(plan);
        }
        public void DeletePlan(Plan plan)
        {
            Delete(plan);
        }

        //public IEnumerable<Plan> GetAllPlans(bool trackChanges) => FindAll(trackChanges)
        //.OrderBy(c => c.Id)
        //.ToList();

        //public Plan GetPlan(Guid planId, bool trackChanges) => FindByCondition(c => c.Id.Equals(planId), trackChanges).SingleOrDefault();
    }
}
