using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById
{
    public class GetCartByIdValidator : AbstractValidator<GetCartByIdCommand>
    {
        public GetCartByIdValidator() 
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Cart Id must be greater than 0");
        }
    }
}
