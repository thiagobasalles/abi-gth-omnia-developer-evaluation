using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart
{
    public class GetRangeCartResult
    {
        public decimal TotalAmount { get; set; }
        public DateTime Date {  get; set; }
        public IList<GetRangeCartItemResult> Products { get; set; } = new List<GetRangeCartItemResult>();
    }
}
