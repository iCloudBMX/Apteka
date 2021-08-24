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

        public async Task<IEnumerable<Dori>> GetAllAsync() => await _context.Dorilar.ToListAsync();

        public async Task<Dori> GetByIdAsync(Guid id) => await _context.Dorilar.FirstOrDefaultAsync(dori => dori.Id == id);
    }
}
