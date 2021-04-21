using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WAD.WebApp._10888.DAL.Repos
{
    public interface IRepos<T> where T : class
    {
        
        Task UpdateAsync(T steak);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        bool Exists(int id);
        Task CreateAsync(T steak);
        Task DeleteAsync(int id);
    }
}
