using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WAD.WebApp._10888.DAL.DBO;

namespace WAD.WebApp._10888.DAL.Repos
{
    public class CategoryRepos : BaseRepos, IRepos<Category>
    {
        public CategoryRepos(SteakDbContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Category category)
        {
            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var status = await _dbContext.Category.FindAsync(id);
            _dbContext.Category.Remove(status);
            await _dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _dbContext.Category.Any(e => e.Id == id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbContext.Category
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
