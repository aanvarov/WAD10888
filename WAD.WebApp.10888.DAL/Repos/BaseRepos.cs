using System;
using System.Collections.Generic;
using System.Text;

namespace WAD.WebApp._10888.DAL.Repos
{
    public class BaseRepos
    {
        protected readonly SteakDbContext _dbContext;

        protected BaseRepos(SteakDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
