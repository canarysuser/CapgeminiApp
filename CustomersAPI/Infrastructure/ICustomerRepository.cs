using CapgAppLibrary;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string customerId);
    }


    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomersDbContext _context;
        public CustomerRepository(CustomersDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Customer> GetCustomer(string customerId)
        {
            if(string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentNullException(nameof(customerId), "Missing value.");
            }
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
