using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetPlans(Guid IDSklad, bool trackChanges);
  
        Plan GetPlan(Guid planId, Guid id ,bool trackChanges);
        void CreatePlan(Guid IDSklad, Guid IDSklad2, Guid productId, Plan plan);

        void DeletePlan(Plan plan);

    }
}
