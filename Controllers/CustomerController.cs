using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _customerService.GetCustomers();
        return Ok(customers);
    }
    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _customerService.GetCustomerById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }
     [HttpPost]
    public IActionResult CreateCustomer(CustomerDto customer)
    {
        var createdCustomer = _customerService.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, CustomerDto customer)
    {
        var updatedCustomer = _customerService.UpdateCustomer(id, customer);
        if (updatedCustomer == null) return NotFound();
        return Ok(updatedCustomer);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var result = _customerService.Deletecustomer(id);
        if (!result) return NotFound();
        return NoContent();
    }
}