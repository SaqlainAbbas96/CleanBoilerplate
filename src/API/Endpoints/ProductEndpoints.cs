using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    /// <summary>
    /// Provides extension methods to map product-related endpoints.
    /// </summary>
    public static class ProductEndpoints
    {
        /// <summary>
        /// Maps the product-related endpoints to the application.
        /// </summary>
        /// <param name="app">The IEndpointRouteBuilder instance used to configure endpoints.</param>
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            // Endpoint to retrieve all products using the IProductService
            app.MapGet("/api/products", async (IProductService service) =>
            {
                try
                {
                    // Calls the service layer to fetch all products asynchronously.
                    var products = await service.GetAllProductsAsync();

                    // Returns 204 No Content if no products are found
                    if (products == null || !products.Any())
                    {
                        return Results.NoContent();
                    }

                    // Returns 200 OK with the list of products
                    return Results.Ok(products);
                }
                catch (Exception ex)
                {
                    // Consider adding a logging service for better error tracking
                    return Results.StatusCode(500);
                }
            })
                .WithName("GetAllProducts") // Assigns a unique name to the endpoint for routing purposes.
                .Produces(200, typeof(IEnumerable<ProductDto>)) // Specifies a 200 OK response with a list of ProductDto
                .Produces(204) // Specifies a 204 No Content response
                .Produces(500); // Specifies a 500 Internal Server Error response

            // Root endpoint to verify the application is running
            app.MapGet("/", () => "Hello World")
                .WithName("RootEndpoint"); // Assigns a unique name to the root endpoint.
        }
    }
}