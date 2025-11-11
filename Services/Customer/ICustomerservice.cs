public interface ICustomerService
{
    List<CustomerDto> GetCustomers();
    CustomerDto? GetCustomerById(int id);
    CustomerDto CreateCustomer(CustomerDto customer);
    CustomerDto? UpdateCustomer(int id, CustomerDto customer);
    bool Deletecustomer(int id); 
}