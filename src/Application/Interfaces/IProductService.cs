using Application.DTOs;

namespace Application.Interfaces
{
    /// <summary>
    /// Interface defining the operations related to products.
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
