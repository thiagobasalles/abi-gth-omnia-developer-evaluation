using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.City)
                .NotEmpty().WithMessage("City cannot be empty.")
                .MaximumLength(100).WithMessage("City length cannot be greater than 100 characters.");

            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(200).WithMessage("Street length cannot be greater than 200 characters.");
            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("Number cannot be empty.")
                .LessThanOrEqualTo(9999999).WithMessage("Number cannot be greater than 9999999");

            RuleFor(a => a.Zipcode)
                .NotEmpty().WithMessage("Zipcode cannot be empty.")
                .MaximumLength(50).WithMessage("Zipcode length cannot be greater than 50 characters.");
        }
    }
}