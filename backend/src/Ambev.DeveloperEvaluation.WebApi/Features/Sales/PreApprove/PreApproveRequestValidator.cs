using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PreApprove
{
    public class PreApproveRequestValidator : AbstractValidator<PreApproveRequest>
    {
        public PreApproveRequestValidator()
        {
            RuleFor(s => s.CartId)
                .NotEmpty().WithMessage("Cart id must be a valid value.");

        }
    }
}
