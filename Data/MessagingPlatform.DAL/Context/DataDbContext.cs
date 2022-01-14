using MessagingPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingPlatform.DAL.Context
{
    public class DataDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options)
        : base(options) { }
    }
}
