using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    /// <summary>
    /// Service class implementing <see cref="IProductService"/> to manage product-related business logic.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="repository">The repository instance to interact with the data source.</param>
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <returns>A collection of <see cref="ProductDto"/> representing all the products.</returns>
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            // Fetch the products from the repository layer
            var products = await _repository.GetAllAsync();

            // Return an empty list if no products are found
            if (products == null || !products.Any())
                return Enumerable.Empty<ProductDto>();

            // Map Product entities to ProductDto
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }
    }
}
