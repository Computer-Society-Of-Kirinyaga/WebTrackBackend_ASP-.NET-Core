using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

public class ProductService :IProductService
{
    private readonly List<ProductDto> products = [];
    public int nextid = 1;
      // Seed with some initial data
    public ProductService()
    {
        products.Add(new ProductDto { Id = nextid++, Name = "Laptop", Description = "Gaming laptop", Price = 999.99m, StockQuantity = 10 });
        products.Add(new ProductDto { Id = nextid++, Name = "Mouse", Description = "Wireless mouse", Price = 29.99m, StockQuantity = 50 });
    }
    public List<ProductDto> GetAllProducts() => products;

    public ProductDto? GetProductById(int id) => products.Find(p => p.Id == id);
    public ProductDto CreateProduct(ProductDto product)
    {
        product.Id = nextid++;
        products.Add(product);
        return product;
    }
    public ProductDto? UpdateProduct(int id, ProductDto product)
    {
        var existingproduct = GetProductById(id);
        if (existingproduct == null) return null;

        existingproduct.Name = product.Name;
        existingproduct.Description = product.Description;
        // existingproduct.Price = product.Price;
        // existingproduct.StockQuantity = product.StockQuantity;
        // existingproduct.IsAvailable = product.IsAvailable;
        return existingproduct;
    }
    public bool DeleteProduct(int id)
    {
        var currProd = GetProductById(id);
        if (currProd == null) return false;
        return products.Remove(currProd);
    }
    public List<ProductDto> GetAvailableProducts() => [.. products.Where(p => p.IsAvailable && p.StockQuantity > 0)];
}