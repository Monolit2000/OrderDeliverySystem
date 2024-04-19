using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.UserAccess.Domain.Users;
using OrderDeliverySystem.UserAccess.Infrastructure.Domain.Users;


namespace OrderDeliverySystem.UserAccess.Infrastructure.Persistence
{
    public class UserAccessContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserAccessContext(DbContextOptions options)
           : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

    }
}
