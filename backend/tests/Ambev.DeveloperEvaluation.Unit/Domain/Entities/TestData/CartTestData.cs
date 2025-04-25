using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data for the Cart and CartItem entities using the Bogus library.
    /// </summary>
    public static class CartTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CartItem entities.
        /// </summary>
        private static readonly Faker<CartItem> CartItemFaker = new Faker<CartItem>()
            .RuleFor(ci => ci.ProductId, f => f.Random.Long(1, 100))
            .RuleFor(ci => ci.Quantity, f => f.Random.Number(1, 30))
            .RuleFor(ci => ci.UnitPrice, f => f.Random.Decimal(1, 100))
            .RuleFor(ci => ci.Discount, 0); 

        /// <summary>
        /// Generates a valid CartItem entity with randomized data.
        /// </summary>
        public static CartItem GenerateCartItem()
        {
            return CartItemFaker.Generate();
        }

        /// <summary>
        /// Generates a CartItem entity with specified quantity and unit price.
        /// </summary>
        /// <param name="quantity">The quantity of the cart item.</param>
        /// <param name="unitPrice">The unit price of the cart item.</param>
        public static CartItem GenerateCartItem(int quantity, decimal unitPrice)
        {
            var faker = new Faker<CartItem>()
                .RuleFor(ci => ci.ProductId, f => f.Random.Long(1, 100))
                .RuleFor(ci => ci.Quantity, quantity)
                .RuleFor(ci => ci.UnitPrice, unitPrice)
                .RuleFor(ci => ci.Discount, 0);
            return faker.Generate();
        }

        /// <summary>
        /// Generates a list of valid CartItem entities with a specified number of items.
        /// </summary>
        /// <param name="count">The number of CartItem entities to generate.</param>
        public static List<CartItem> GenerateCartItems(int count)
        {
            return CartItemFaker.Generate(count);
        }

        /// <summary>
        /// Generates a valid Cart entity with randomized data, including a list of CartItems.
        /// </summary>
        public static Cart GenerateValidCart()
        {
            var faker = new Faker<Cart>()
                .RuleFor(c => c.Id, f => f.Random.Long(1, 100))
                .RuleFor(c => c.UserId, f => f.Random.Guid())
                .RuleFor(c => c.BranchId, f => f.Random.Long(1, 10))
                .RuleFor(c => c.Date, f => f.Date.Past())
                .RuleFor(c => c.TotalAmount, 0) // Initial total amount is zero
                .RuleFor(c => c.Products, f => GenerateCartItems(f.Random.Number(1, 5)));
            return faker.Generate();
        }

    }
}
