using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart
    {
        public long Id { get; set; }
        /// <summary>
        /// Gets the user's id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the branch id.
        /// </summary>
        public long BranchId { get; set; }

        /// <summary>
        /// Gets the date of the cart.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the total amount of the cart.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets the list of products in the cart.
        /// </summary>
        public IList<CartItem> Products { get; set; } = new List<CartItem>();

        public void ApplyDiscountsAndCalculateTotal()
        {
            foreach (var item in Products)
                item.CalculateDiscount();

            TotalAmount = Products.Sum(p => (p.UnitPrice * p.Quantity) - p.Discount);
        }
        
    }
}
