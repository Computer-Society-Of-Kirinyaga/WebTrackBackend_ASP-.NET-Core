using Ecommerce.Api.Dtos;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context; 
       

       [HttpPost("register")]
       public ActionResult<Customer> Register(AuthDto request)
        {
             var customer = new Customer();
            var HashedPassword = new PasswordHasher<Customer>().HashPassword(customer, request.PasswordHash);
        } 
    }
}
