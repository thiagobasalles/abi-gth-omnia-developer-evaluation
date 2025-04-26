using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart
{
    public class GetRangeCartCommand : IRequest<IQueryable<GetRangeCartResult>>
    {
        public GetRangeCartCommand()
        {
        }
    }
}
