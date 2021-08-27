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
    public class DoriRepo : IDoriRepo
    {
        private readonly AppDbContext _context;

        public DoriRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dori> CreateAsync(IList<Guid> ids, Dori dori)
        {
            foreach (var id in ids)
            {
                var firma = await _context.Firmalar.FirstOrDefaultAsync(firma => firma.Id == id);

                if(firma is not null)
                {
                    dori.Firmalar.Add(firma);
                }
            }
            
            await _context.AddAsync(dori);

            await _context.SaveChangesAsync();

            return dori;
        }

        public async Task DeleteAsync(Dori dori)
        {
            _context.Remove(dori);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dori>> GetAllAsync() => await _context.Dorilar.Include(dori => dori.Firmalar).ToListAsync();

        public async Task<Dori> GetByIdAsync(Guid id) => await _context.Dorilar.FirstOrDefaultAsync(dori => dori.Id == id);

        public async Task UpdateAsync(Dori doriDto)
        {
            await _context.SaveChangesAsync();
        }
    }
}
