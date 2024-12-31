using API.Tests.Helpers;
using Application.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace API.Tests;

/// <summary>
/// Integration tests for the Product API endpoints.
/// </summary>
public class ProductIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductIntegrationTests"/> class.
    /// </summary>
    /// <param name="factory">The custom web application factory used to create the test client.</param>
    public ProductIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/api/products");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsProductList()
    {
        // Act
        var response = await _client.GetFromJsonAsync<List<ProductDto>>("/api/products");

        // Assert
        Assert.NotNull(response);
        Assert.NotEmpty(response);
        Assert.All(response, product => Assert.NotNull(product.Name));
    }
}