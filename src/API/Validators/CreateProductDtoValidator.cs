using Application.DTOs;
using FluentValidation;

namespace API.Validators
{
    /// <summary>
    /// Provides validation rules for the <see cref="ProductDto"/> during creation.
    /// </summary>
    public class CreateProductDtoValidator : AbstractValidator<ProductDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductDtoValidator"/> class.
        /// Defines validation rules for creating a product.
        /// </summary>
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters");
        }
    }
}
