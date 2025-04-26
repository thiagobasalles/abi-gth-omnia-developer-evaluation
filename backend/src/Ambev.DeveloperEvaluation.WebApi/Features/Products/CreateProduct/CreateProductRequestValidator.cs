using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {

        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price of product must be greather than 0");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title cannot be empty");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description cannot be empty");

            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Image url cannot be empty");

            RuleFor(p => p.Rating)
                .NotNull().WithMessage("Rating cannot be null");

            RuleFor(p => p.Rating.Count)
                .GreaterThanOrEqualTo(0).WithMessage("Rating count must be greather than or equals 0")
                .When(p => p.Rating != null);

            RuleFor(p => p.Rating.Rate)
                .InclusiveBetween(0, 10).WithMessage("Rate must be between 0 and 10")
                .When(p => p.Rating != null);


        }

    }
}
