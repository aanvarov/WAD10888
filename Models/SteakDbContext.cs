using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.WebApp._10888.Models
{
    public class SteakDbContext : DbContext
    {
        public SteakDbContext()
        {

        }

        public DbSet<Steak> Steak { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
