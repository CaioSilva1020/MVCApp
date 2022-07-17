using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Data
{
    public class MVCAppContext : DbContext
    {
        public MVCAppContext (DbContextOptions<MVCAppContext> options)
            : base(options)
        {
        }

        public MVCAppContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DCTJSEI\\SQLEXPRESS02;Database=MVCApp;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("MvcApp"));
        }

        public DbSet<MVCApp.Models.Usuario>? Usuario { get; set; }
    }
}
