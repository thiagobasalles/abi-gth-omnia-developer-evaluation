using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Cancel
{
    public class CancelValidator : AbstractValidator<CancelCommand>
    {
        public CancelValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("Sale ID must be a valid");

        }
    }
}
