using Azure.Core;
using CapgAppLibrary;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure
{
    public interface IUserRepository
    {
        bool Authenticate(AuthenticationRequest request);

        User GetUserDetails(string email); 
    }

    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        public UserRepository(UsersDbContext context)
            => _context = context; 

        public bool Authenticate(AuthenticationRequest request)
        {
            if (request is null)
                throw new ArgumentNullException("request", "Cannot be null.");
            var item = _context.Users.FirstOrDefault(
                c => c.Email.Equals(request.Email) && c.Password.Equals(request.Password)
            );
            if (item is null)
                throw new Exception("Requested item not found.");
            else
                return true;
        }
        public User GetUserDetails(string email)
        {
            if (email is null)
                throw new ArgumentNullException("email", "Cannot be null."); 
            var item = _context.Users
                    .FirstOrDefault(c => c.Email.Equals(email));
            if (item is null)
                throw new Exception("Requested item not found.");
            else
                return item;
        }
    }
}
