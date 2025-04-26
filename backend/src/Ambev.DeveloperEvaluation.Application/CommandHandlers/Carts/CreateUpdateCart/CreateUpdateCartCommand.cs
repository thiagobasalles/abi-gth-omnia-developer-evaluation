using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart
{
    public class CreateUpdateCartCommand : IRequest<CreateUpdateCartResult>
    {
        public Guid UserId { get;  }
        public DateTime Date { get; }
        public IList<CreateUpdateCartItemDto> Products { get; } = new List<CreateUpdateCartItemDto>();

        public CreateUpdateCartCommand(Guid userId, DateTime date, IList<CreateUpdateCartItemDto> products)
        {
            UserId = userId;
            Date = date;
            Products = products;
        }
    }
}
