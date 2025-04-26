using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart
{
    public class CreateUpdateCartValidator : AbstractValidator<CreateUpdateCartCommand>
    {
        public CreateUpdateCartValidator() 
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("User id cannot be empty or null");

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
