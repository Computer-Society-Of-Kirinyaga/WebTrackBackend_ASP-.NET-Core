using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;
    

    [HttpPost]
    public async Task<IActionResult> createProduct (ProductDto product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
     [HttpGet]
    public async Task<IActionResult> GetProduct ()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct (int id, [FromBody]ProductDto product)
        {
            try
            {
                if(id != product.Id) return BadRequest($"id does not match!!! ");
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }    
}
}
