using CapgAppLibrary;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Infrastructure
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) 
            : base(options)
        {
        }
        //Resolve the namespace
        public DbSet<Customer> Customers { get; set; }

    }
} 
