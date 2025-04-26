using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById
{
    public class GetByIdWithRatingRequestValidator : AbstractValidator<GetByIdWithRatingRequest>
    {
        public GetByIdWithRatingRequestValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Product id is required");
        }
    }
}
