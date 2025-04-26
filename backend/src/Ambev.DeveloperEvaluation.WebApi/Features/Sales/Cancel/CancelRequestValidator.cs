using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Cancel
{
    public class CancelRequestValidator : AbstractValidator<CancelRequest>
    {
        public CancelRequestValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Sale ID is required.");
        }
    }
}
