using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart
{
    public class GetRangeCartRequestValidator : AbstractValidator<GetRangeCartRequest>
    {
        public GetRangeCartRequestValidator() 
        {
            RuleFor(c => c.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Cart page be greater than or equals 1");
            RuleFor(c => c.Size)
                .GreaterThanOrEqualTo(10).WithMessage("Cart size be greater than or equals 10");
        }
    }
}
