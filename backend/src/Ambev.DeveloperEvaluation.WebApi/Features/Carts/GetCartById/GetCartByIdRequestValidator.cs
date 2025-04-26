using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{
    public class GetCartByIdRequestValidator : AbstractValidator<GetCartByIdRequest>
    {
        public GetCartByIdRequestValidator() 
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Cart Id must be greater than 0");
        }
    }
}
