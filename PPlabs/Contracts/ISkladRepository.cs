using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISkladRepository
    {
        Task<IEnumerable<Sklad>> GetAllSkladsAsync(bool trackChanges);
        Task<Sklad> GetSkladAsync(Guid IDSкlad, bool trackChanges);

        Task<IEnumerable<Sklad>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        //Sklad GetSklad(Guid skladId, bool trackChanges);
        void CreateSklad(Sklad sklad);

        void DeleteSklad(Sklad sklad);
    }
}
