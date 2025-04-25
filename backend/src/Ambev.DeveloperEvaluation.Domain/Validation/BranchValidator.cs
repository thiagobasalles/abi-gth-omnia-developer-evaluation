using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name cannot be empty")
                .MaximumLength(50).WithMessage("Branch name length cannot be greater than 50 characters");

        }
    }
}
