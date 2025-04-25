using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public void CalculateDiscount()
        {
            if (Quantity > 20)
                throw new DomainException("Cannot buy more than 20 identical items.");

            decimal discountPercentage = 0m;

            if (Quantity >= 10)
                discountPercentage = 0.20m;
            else if (Quantity >= 4)
                discountPercentage = 0.10m;

            var totalWithoutDiscount = UnitPrice * Quantity;
            Discount = totalWithoutDiscount * discountPercentage;
        }
    }
}
