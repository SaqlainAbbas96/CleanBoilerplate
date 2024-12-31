using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a product.
    /// </summary>
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
