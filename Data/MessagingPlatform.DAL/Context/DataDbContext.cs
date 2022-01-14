using MessagingPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingPlatform.DAL.Context
{
    public class DataDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataDbContext()
        {}
        public DataDbContext(DbContextOptions<DataDbContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=MessagingPlatform.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
