using CapgAppLibrary;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set the primary key
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            //insert rows into the table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = "admin",
                    RoleName = "Admin",
                    Email = "admin@example.com"
                },
                new User
                {
                    UserId = 2,
                    UserName = "user",
                    Password = "user",
                    RoleName = "User",
                    Email = "user@example.com"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
