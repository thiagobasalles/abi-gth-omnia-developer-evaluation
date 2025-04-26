using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById
{
    public class GetCartByIdResult
    {
        public long Id {  get; set; }
        public Guid UserId { get; set; }
        public DateTime Date {  get; set; }
        public IList<GetCartByIdItemResult> Products { get; set; } = new List<GetCartByIdItemResult>();

    }
}
