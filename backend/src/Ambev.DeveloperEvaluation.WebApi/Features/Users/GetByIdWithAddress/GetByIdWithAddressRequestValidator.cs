using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressRequestValidator : AbstractValidator<GetByIdWithAddressRequest>
    {
        public GetByIdWithAddressRequestValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("User ID is Required");
        }
    }
}
