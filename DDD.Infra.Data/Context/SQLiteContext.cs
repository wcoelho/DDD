using Microsoft.EntityFrameworkCore;
using DDD.Domain.Entities;
using DDD.Infra.Data.Mapping;

namespace DDD.Infra.Data.Context
{
    public class SQLiteContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CheckingAccount> CheckingAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilizando um servidor SQLite local. Aqui poderíamos configurar qualquer outro banco de dados.
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("DataSource=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<CheckingAccount>(new CheckingAccountMap().Configure);
        }
    }
}