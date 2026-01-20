using System.Security.Claims;
using Ecommerce.Api.Dtos;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AppDbContext context, IConfiguration _configuration ) : ControllerBase
    {
        private readonly AppDbContext _context = context; 
        private readonly IConfiguration configuration = _configuration;
       

       [HttpPost("register")]
       public async Task<ActionResult<Customer>> Register(AuthDto request)
        {
           if(_context.Customers.Any(u => u.Email == request.Email)) return BadRequest("email already exists");
       var customer = new Customer
       {
           Email = request.Email
       };
       customer.PasswordHash = new PasswordHasher<Customer>().HashPassword(customer, request.PasswordHash);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        customer.PasswordHash = "";
        return Ok(customer);
        
        } 

        [HttpPost("login")]
        public async Task<ActionResult<Customer>> Login(AuthDto request)
        {
            var FoundCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == request.Email);
            if(FoundCustomer == null) return Unauthorized("invalid log in credentials");

            var result = new PasswordHasher<Customer>().VerifyHashedPassword(FoundCustomer, FoundCustomer.PasswordHash, request.PasswordHash);
            if (result == PasswordVerificationResult.Failed) return Unauthorized("invalid Password");
        
        //generate jwt token and return
        var token =  GenerateJwt(FoundCustomer);
        return Ok(token);

        }
        public string GenerateJwt (Customer customer)
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()), 
              new(ClaimTypes.Email, customer.Email) 
            };
            
            var Mykey = configuration["Jwt: Key"];
            if (string.IsNullOrEmpty(Mykey)) throw new Exception("Jwt key is missing");

            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(Mykey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt: Issuer"],
                audience: configuration["Jwt: Audience"] ,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
       
    }
}
