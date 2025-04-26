using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingCommand : IRequest<IQueryable<GetByCategoryWithRatingResult>>
    {
        public string Category { get; }
        public string Order { get; }    

        public GetByCategoryWithRatingCommand(string category, string order)
        {
            Category = category;
            Order = order;
        }
    }
}
