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
        IEnumerable<Sklad> GetAllSklads(bool trackChanges);

        Sklad GetSklad(Guid skladId, bool trackChanges);
    }
}
