using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WAD.WebApp._10888.DAL.DBO;
using System.Threading.Tasks;

namespace WAD.WebApp._10888.DAL.Repos
{
    public class SteakRepos : BaseRepos, IRepos<Steak>
    {
        public SteakRepos(SteakDbContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Steak steak)
        {
            _dbContext.Add(steak);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var steak = await _dbContext.Steak.FindAsync(id);
            _dbContext.Steak.Remove(steak);
            await _dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _dbContext.Steak.Any(a => a.Id == id);
        }

        public async Task<List<Steak>> GetAllAsync()
        {
            return await _dbContext.Steak.Include(a => a.Category).ToListAsync();
        }


        public async Task<Steak> GetByIdAsync(int id)
        {
            return await _dbContext.Steak
               .Include(a => a.Category)
               .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Steak steak)
        {
            _dbContext.Update(steak);
            await _dbContext.SaveChangesAsync();
        }
    }
}
