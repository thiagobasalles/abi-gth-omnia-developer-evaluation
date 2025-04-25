using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the CartItem entity class.
    /// </summary>
    public class CartItemTests
    {
        /// <summary>
        /// Tests that the discount is not applied when the quantity is less than 4.
        /// </summary>
        [Fact(DisplayName = "Discount should be zero for quantity less than 4")]
        public void Given_QuantityLessThan4_When_CalculateDiscount_Then_DiscountShouldBeZero()
        {
            var cartItem = CartTestData.GenerateCartItem(quantity: 3, unitPrice: 10);

            cartItem.CalculateDiscount();

            Assert.Equal(0, cartItem.Discount);
        }

        /// <summary>
        /// Tests that a 10% discount is applied when the quantity is between 4 and 9.
        /// </summary>
        [Fact(DisplayName = "Discount should be 10% for quantity between 4 and 9")]
        public void Given_QuantityBetween4And9_When_CalculateDiscount_Then_DiscountShouldBe10Percent()
        {
            var quantity = new Faker().Random.Number(4, 9);
            var unitPrice = new Faker().Random.Decimal(1, 100);
            var cartItem = CartTestData.GenerateCartItem(quantity: quantity, unitPrice: unitPrice);
            var expectedDiscount = unitPrice * quantity * 0.10m;

            cartItem.CalculateDiscount();

            Assert.Equal(expectedDiscount, cartItem.Discount);
        }

        /// <summary>
        /// Tests that a 20% discount is applied when the quantity is 10 or more.
        /// </summary>
        [Fact(DisplayName = "Discount should be 20% for quantity 10 or more")]
        public void Given_Quantity10OrMore_When_CalculateDiscount_Then_DiscountShouldBe20Percent()
        {
            var quantity = new Faker().Random.Number(10, 20);
            var unitPrice = new Faker().Random.Decimal(1, 100);
            var cartItem = CartTestData.GenerateCartItem(quantity: quantity, unitPrice: unitPrice);
            var expectedDiscount = unitPrice * quantity * 0.20m;

            cartItem.CalculateDiscount();

            Assert.Equal(expectedDiscount, cartItem.Discount);
        }

        /// <summary>
        /// Tests that a DomainException is thrown when the quantity exceeds 20.
        /// </summary>
        [Fact(DisplayName = "CalculateDiscount should throw DomainException if quantity exceeds 20")]
        public void Given_QuantityGreaterThan20_When_CalculateDiscount_Then_ShouldThrowDomainException()
        {
            var cartItem = CartTestData.GenerateCartItem(quantity: 21, unitPrice: 10);

            Assert.Throws<DomainException>(() => cartItem.CalculateDiscount());
        }
    }
}