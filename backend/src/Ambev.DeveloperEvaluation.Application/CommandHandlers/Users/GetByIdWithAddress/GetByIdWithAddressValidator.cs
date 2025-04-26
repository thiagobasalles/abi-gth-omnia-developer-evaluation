using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressValidator : AbstractValidator<GetByIdWithAddressCommand>
    {
        public GetByIdWithAddressValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("User ID is required");
        }
    }
}
