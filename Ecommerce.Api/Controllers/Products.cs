using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/pexroducts");

        group.MapGet("/", (IProductService service) =>
        {
            var products = service.GetAllProducts();
            return Results.Ok(products);
        });
          group.MapGet("/available", (IProductService service) =>
        {
            var products = service.GetAvailableProducts();
            return Results.Ok(products);
        });
        group.MapGet("/{id}", (int id, IProductService service) =>
        {
            var product = service.GetProductById(id);
            return product is null ? Results.NotFound() : Results.Ok(product);
        })
        .WithName("GetProductById");
        group.MapPost("/", (ProductDto product, IProductService service) =>
        {
            var createdProduct = service.CreateProduct(product);
            return Results.CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, createdProduct);
        });
        group.MapDelete("/{id}", (int id, IProductService service) =>
        {
            return service.DeleteProduct(id);
        });
        group.MapPatch("/{id}", (int id, IProductService service, ProductDto product) =>
        {
            var updatedProduct = service.UpdateProduct(id, product);
            return Results.Ok(product);
        });
        return group;
    }
}