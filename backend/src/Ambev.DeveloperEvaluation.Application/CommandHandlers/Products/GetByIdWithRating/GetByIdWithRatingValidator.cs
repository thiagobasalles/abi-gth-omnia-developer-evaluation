using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating
{
    public class GetByIdWithRatingValidator : AbstractValidator<GetByIdWithRatingCommand>
    {
        public GetByIdWithRatingValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Product id is required");
        }
    }
}
