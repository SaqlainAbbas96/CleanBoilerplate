using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Application.Tests;

/// <summary>
/// Unit tests for the ProductService.
/// </summary>
public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepository;
    private readonly ProductService _service;

    /// <summary>
    /// Initializes a new instance of the ProductServiceTests class.
    /// </summary>
    public ProductServiceTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllProductsAsync_ShouldReturnListOfProducts()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1" },
                new Product { Id = 2, Name = "Test Product 2" }
            };
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

        // Act
        var result = await _service.GetAllProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Test Product 1");
        Assert.Contains(result, p => p.Name == "Test Product 2");
    }
}
