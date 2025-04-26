using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart
{
    public class CreateUpdateCartResult
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public IList<CreateUpdateCartItemDto>? Products { get; set; } = new List<CreateUpdateCartItemDto>();
    }
}
