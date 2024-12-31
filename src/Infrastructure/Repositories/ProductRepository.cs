using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Represents the repository responsible for managing <see cref="Product"/> entities in the database.
    /// Inherits from the <see cref="GenericRepository{Product}"/> class to provide CRUD operations for products.
    /// </summary>
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class with the specified <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="dbContext">The <see cref="ApplicationDbContext"/> instance used to interact with the database.</param>
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // Pass the dbContext to the base GenericRepository class
        }
    }
}
