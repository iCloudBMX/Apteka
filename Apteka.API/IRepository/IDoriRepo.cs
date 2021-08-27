using Apteka.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.IRepository
{
    public interface IDoriRepo
    {
        Task<IEnumerable<Dori>> GetAllAsync();

        Task<Dori> GetByIdAsync(Guid id);

        Task<Dori> CreateAsync(IList<Guid>ids, Dori dori);

        Task UpdateAsync(Dori dori);

        Task DeleteAsync(Dori dori);
    }
}
