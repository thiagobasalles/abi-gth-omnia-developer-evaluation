using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart
{
    public class CreateUpdateCartRequestValidator : AbstractValidator<CreateUpdateCartRequest>
    {
        public CreateUpdateCartRequestValidator()
        {

            RuleFor(c => c.Products.Count)
                .GreaterThanOrEqualTo(1).WithMessage("The Product item list cannot be 0");

            RuleFor(c => c.Products)
                .Must(products => products.All(p => p.ProductId > 0))
                .WithMessage("Product id cannot be 0 or negative");

            RuleFor(c => c.Products)
                .Must(products => products.All(p => p.Quantity > 0))
                .WithMessage("Quantity cannot be 0 or negative");

            RuleFor(c => c.Products)
                .Must(products => products.Select(p => p.ProductId).Distinct().Count() == products.Count)
                .WithMessage("Product id must be unique. Duplicate products are not allowed.");
        }
    }
}
