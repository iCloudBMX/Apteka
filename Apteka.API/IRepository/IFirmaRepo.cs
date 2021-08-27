using Apteka.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.IRepository
{
    public interface IFirmaRepo
    { 
        Task<IEnumerable<DoriFirma>> GetAllAsync();

        Task<DoriFirma> GetByIdAsync(Guid id);

        Task<DoriFirma> CreateAsync(DoriFirma dori);

        Task UpdateAsync(DoriFirma dori);

        Task DeleteAsync(DoriFirma dori);
    }
}
