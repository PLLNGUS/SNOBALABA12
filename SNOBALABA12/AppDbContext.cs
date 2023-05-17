using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
/*using System.Runtime.Remoting.Contexts;*/
using System.Text;
using System.Threading.Tasks;

namespace LABA12
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=RepairDb;Integrated Security=True;";

        public DbSet<Clients> Client { get; set; }
        public DbSet<Orderss> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .HasMany(u => u.Orders)
                .WithOne(b => b.Client)
                .HasForeignKey(b => b.ClientId);
        }

    }
}
