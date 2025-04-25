using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be grater than 0.0");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category cannot be empty.")
                .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.");

            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Url image cannot be empty.")
                .MaximumLength(300).WithMessage("Url image cannot exceed 300 characters.");

        }

    }
}
