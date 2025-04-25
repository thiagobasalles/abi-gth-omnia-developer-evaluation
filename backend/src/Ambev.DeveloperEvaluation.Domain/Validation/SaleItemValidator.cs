using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(s => s.Quantity)
                .GreaterThan(0).WithMessage("Quantity cannot be less than or equal to zero.");

            RuleFor(s => s.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price cannot be less than zero.");

            RuleFor(s => s.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be less than zero.");
        }
    }
}
