using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Lanches.Models;

namespace WebApi_Lanches.Data
{
    public class LanchesContext : DbContext
    {
        public LanchesContext(DbContextOptions<LanchesContext> options)
            :base(options)
        {
        }

        public DbSet<Lanches> Lanches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Lanches>().HasKey(m => m.LancheId);
            base.OnModelCreating(builder);
        }

    }
}
