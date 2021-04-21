using Microsoft.EntityFrameworkCore;
using System;
using WAD.WebApp._10888.DAL.DBO;

namespace WAD.WebApp._10888.DAL
{
    public class SteakDbContext : DbContext
    {
        public SteakDbContext(DbContextOptions<SteakDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Steak> Steak { get; set; }

        public virtual DbSet<Category> Category { get; set; }
    }
}
