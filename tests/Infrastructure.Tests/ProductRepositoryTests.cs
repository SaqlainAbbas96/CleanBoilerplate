using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests;

/// <summary>
/// Unit tests for the ProductRepository class.
/// </summary>
public class ProductRepositoryTests
{
    private readonly ApplicationDbContext _context;
    private readonly ProductRepository _repository;

    /// <summary>
    /// Initializes the test class and sets up the in-memory database and repository.
    /// </summary>
    public ProductRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        _context = new ApplicationDbContext(options);
        _repository = new ProductRepository(_context);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Arrange
        _context.Products.Add(new Product { Id = 1, Name = "Test Product 1" });
        _context.Products.Add(new Product { Id = 2, Name = "Test Product 2" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Test Product 1");
        Assert.Contains(result, p => p.Name == "Test Product 2");
    }
}
