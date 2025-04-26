using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove
{
    public class PreApproveValidator : AbstractValidator<PreApproveCommand>
    {
        public PreApproveValidator()
        {
            RuleFor(s => s.CartId)
                .GreaterThan(0).WithMessage("Cart id must be a valid value.");

        }
    }
}
