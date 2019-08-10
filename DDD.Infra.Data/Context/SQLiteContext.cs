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
        public DbSet<Transaction> Transaction { get; set; }

        bool _useInMemory = false;

        public SQLiteContext(bool useInMemory) {
            _useInMemory = (useInMemory)? useInMemory : false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                if (_useInMemory)
                    optionsBuilder.UseInMemoryDatabase(databaseName: "test1");
                else
                    optionsBuilder.UseSqlite("DataSource=app.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<CheckingAccount>(new CheckingAccountMap().Configure);
            modelBuilder.Entity<Transaction>(new TransactionMap().Configure);
        }
    }
}