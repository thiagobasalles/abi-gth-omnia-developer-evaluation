using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Approve
{
    public class ApproveRequestValidator : AbstractValidator<ApproveRequest>
    {
        public ApproveRequestValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Sale id must be valid.");
        }
    }
}
