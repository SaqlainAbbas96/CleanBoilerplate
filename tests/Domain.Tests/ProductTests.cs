using Domain.Entities;

namespace Domain.Tests;

/// <summary>
/// Unit tests for the Product entity.
/// </summary>
public class ProductTests
{
    [Fact]
    public void Product_Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var id = 1;
        var name = "Test Product";

        // Act
        var product = new Product { Id = id, Name = name };

        // Assert
        Assert.Equal(id, product.Id);
        Assert.Equal(name, product.Name);
    }
}
