public interface IProductService
{
    List<ProductDto> GetAllProducts();
    ProductDto? GetProductById(int id);
    ProductDto CreateProduct(ProductDto product);
    ProductDto? UpdateProduct(int id, ProductDto product);
    bool DeleteProduct(int id);
    List<ProductDto> GetAvailableProducts();
}