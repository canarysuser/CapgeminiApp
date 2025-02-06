using AuthenticationService.Infrastructure;
using CapgAppLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TokenManager _tokenManager; 
        private readonly IUserRepository _userRepository;
        public AccountsController(TokenManager tokenManager, IUserRepository repository)
        {
            _tokenManager = tokenManager;
            _userRepository = repository;
        }

        [HttpPost("signin")]
        public ActionResult<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            if (request is null)
                return BadRequest("Invalid request");
            try
            {
                string token = _tokenManager.GetJwtToken(request);

                if (string.IsNullOrEmpty(token))
                    return Unauthorized("Cannot access the resource");
                
                User user = _userRepository.GetUserDetails(request.Email);
                
                var authResponse = new AuthenticationResponse
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    RoleName = user.RoleName,
                    Expires = DateTime.Now.AddDays(1),
                    Token = token
                };

                return Ok(authResponse);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<User> Validate()
        {
            var user = HttpContext.Items["User"] as User;
            if (user is not null)
            {
                return Ok(user);
            } 
            return Unauthorized();
        }
    }
}
