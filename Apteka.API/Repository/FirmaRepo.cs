using Apteka.API.Contexts;
using Apteka.API.IRepository;
using Apteka.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Repository
{
    public class FirmaRepo : IFirmaRepo
    {
        private readonly AppDbContext _context;

        public FirmaRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DoriFirma> CreateAsync(DoriFirma firma)
        {
            await _context.AddAsync(firma);

            await _context.SaveChangesAsync();

            return firma;
        }

        public async Task DeleteAsync(DoriFirma firma)
        {
            _context.Remove(firma);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoriFirma>> GetAllAsync() => await _context.Firmalar.ToListAsync();

        public async Task<DoriFirma> GetByIdAsync(Guid id) => await _context.Firmalar.FirstOrDefaultAsync(firma => firma.Id == id);

        public async Task UpdateAsync(DoriFirma firmaDto)
        {
            await _context.SaveChangesAsync();
        }
    }
}
