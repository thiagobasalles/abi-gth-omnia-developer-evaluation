using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart
{
    public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
    {
        public DeleteCartRequestValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Cart id must be greather than 0");
        }
    }
}
