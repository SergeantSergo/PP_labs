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
        Task<IEnumerable<Plan>> GetPlansAsync(Guid productId, bool trackChanges);

        Task<Plan> GetPlanAsync(Guid IDSklad, Guid id ,bool trackChanges);
        void CreatePlan(Guid IDSklad, Guid IDSklad2, Guid productId, Plan plan);

        void DeletePlan(Plan plan);
        
    }
}
