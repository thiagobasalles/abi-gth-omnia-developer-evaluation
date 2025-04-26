using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts
{
    public class GetPaginatedProductsCommand : IRequest<IQueryable<GetPaginatedProductsResult>>
    {
        public string Order { get; }
        public GetPaginatedProductsCommand(string order)
        {
            Order = order;
        }
    }
}
