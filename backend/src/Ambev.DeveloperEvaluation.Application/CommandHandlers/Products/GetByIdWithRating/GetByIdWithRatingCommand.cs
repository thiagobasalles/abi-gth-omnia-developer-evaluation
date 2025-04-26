using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating
{
    public class GetByIdWithRatingCommand : IRequest<GetByIdWithRatingResult>
    {
        public long Id { get; }

        public GetByIdWithRatingCommand(long id)
        {
            Id = id;
        }
    }
}
