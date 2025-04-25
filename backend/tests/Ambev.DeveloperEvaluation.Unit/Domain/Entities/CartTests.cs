using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Cart entity class.
    /// </summary>
    public class CartTests
    {
        /// <summary>
        /// Tests that the TotalAmount is zero when a new cart is created.
        /// </summary>
        [Fact(DisplayName = "TotalAmount should be zero for a new cart")]
        public void Given_NewCart_Then_TotalAmountShouldBeZero()
        {
            var cart = new Cart();

            Assert.Equal(0, cart.TotalAmount);
        }

        /// <summary>
        /// Tests that the TotalAmount is calculated correctly for a cart with items and no discounts.
        /// </summary>
        [Fact(DisplayName = "TotalAmount should be calculated correctly with no discounts")]
        public void Given_CartWithItemsNoDiscount_When_ApplyDiscountsAndCalculateTotal_Then_TotalAmountIsCorrect()
        {
            var cart = new Cart
            {
                Products = new List<CartItem>
            {
                CartTestData.GenerateCartItem(quantity: 2, unitPrice: 10),
                CartTestData.GenerateCartItem(quantity: 3, unitPrice: 5)
            }
            };
            var expectedTotal = (2 * 10) + (3 * 5);

            cart.ApplyDiscountsAndCalculateTotal();

            Assert.Equal(expectedTotal, cart.TotalAmount);
        }

        /// <summary>
        /// Tests that discounts are applied to cart items and the TotalAmount is calculated correctly.
        /// </summary>
        [Fact(DisplayName = "TotalAmount should be calculated correctly with discounts")]
        public void Given_CartWithItemsWithDiscounts_When_ApplyDiscountsAndCalculateTotal_Then_TotalAmountIsCorrect()
        {
            var cart = new Cart
            {
                Products = new List<CartItem>
            {
                CartTestData.GenerateCartItem(quantity: 5, unitPrice: 10), // 10% discount
                CartTestData.GenerateCartItem(quantity: 12, unitPrice: 5) // 20% discount
            }
            };
            var expectedTotal = (5 * 10 * 0.90m) + (12 * 5 * 0.80m);

            cart.ApplyDiscountsAndCalculateTotal();

            Assert.Equal(expectedTotal, cart.TotalAmount);
            Assert.All(cart.Products.Where(p => p.Quantity >= 4 && p.Quantity <= 9), item => Assert.Equal(item.UnitPrice * item.Quantity * 0.10m, item.Discount));
            Assert.All(cart.Products.Where(p => p.Quantity >= 10), item => Assert.Equal(item.UnitPrice * item.Quantity * 0.20m, item.Discount));
        }

        /// <summary>
        /// Tests that the ApplyDiscountsAndCalculateTotal method handles an empty product list correctly.
        /// </summary>
        [Fact(DisplayName = "ApplyDiscountsAndCalculateTotal should handle empty product list")]
        public void Given_CartWithNoProducts_When_ApplyDiscountsAndCalculateTotal_Then_TotalAmountIsZero()
        {
            var cart = new Cart { Products = new List<CartItem>() };

            cart.ApplyDiscountsAndCalculateTotal();

            Assert.Equal(0, cart.TotalAmount);
        }

        /// <summary>
        /// Tests that DomainException is thrown when trying to add more than 20 identical items to the cart.
        /// </summary>
        [Fact(DisplayName = "ApplyDiscountsAndCalculateTotal should throw DomainException for quantity exceeding 20 in an item")]
        public void Given_CartItemQuantityGreaterThan20_When_ApplyDiscountsAndCalculateTotal_Then_ThrowsDomainException()
        {
            var cart = new Cart
            {
                Products = new List<CartItem>
            {
                CartTestData.GenerateCartItem(quantity: 25, unitPrice: 10)
            }
            };

            Assert.Throws<DomainException>(() => cart.ApplyDiscountsAndCalculateTotal());
        }
    }
}