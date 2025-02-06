using CustomersAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerRepository _repository;
        public CustomersController(ICustomerRepository repository)
            => _repository = repository;

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _repository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("details/{customerId}")]
        public async Task<IActionResult> GetCustomer(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest("Customer Id is required.");
            }
            try
            {
                var customer = await _repository.GetCustomer(customerId);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            //In appsettings.json - add "ConnectionStrings": { 
            // "DefaultConnection":"....."
            //}

        }
    }
}
