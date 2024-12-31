using Domain.Entities;

namespace Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a product repository, inheriting from the generic repository interface.
    /// This repository manages <see cref="Product"/> entities and provides CRUD operations specific to products.
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product>
    {
        // The IProductRepository inherits all CRUD operations from IGenericRepository<Product>,
        // so no additional methods are needed unless there are product-specific operations.
    }
}
