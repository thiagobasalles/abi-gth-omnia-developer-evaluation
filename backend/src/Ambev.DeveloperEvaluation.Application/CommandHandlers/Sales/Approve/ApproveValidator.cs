using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Approve
{
    public class ApproveValidator : AbstractValidator<ApproveCommand>
    {
        public ApproveValidator()
        {
            RuleFor(s => s.Id)
                .GreaterThan(0).WithMessage("Sale id must be valid.");
        }
    }
}
