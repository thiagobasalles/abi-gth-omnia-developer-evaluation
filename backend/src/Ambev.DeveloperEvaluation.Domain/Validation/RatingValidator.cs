using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(r => r.Rate)
                .GreaterThan(0).WithMessage("Rate must be great than 0.")
                .LessThan(10).WithMessage("Rate must be less than 10.");

        }
    }
}
