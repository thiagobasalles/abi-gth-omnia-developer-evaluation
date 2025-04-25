using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the SaleItem entity class.
    /// Currently, there are no specific behaviors to test beyond basic property setting.
    /// More tests can be added if business logic is introduced to SaleItem later.
    /// </summary>
    public class SaleItemTests
    {
        /// <summary>
        /// Tests that a SaleItem can be created with valid properties.
        /// </summary>
        [Fact(DisplayName = "Can create a SaleItem with valid properties")]
        public void Given_ValidSaleItemProperties_When_CreateSaleItem_Then_SaleItemIsCreated()
        {
            var saleItem = SaleTestData.GenerateValidSaleItem();

            Assert.NotEqual(0, saleItem.Id);
            Assert.NotEqual(0, saleItem.SaleId);
            Assert.NotEqual(0, saleItem.ProductId);
            Assert.NotEqual(0, saleItem.Quantity);
            Assert.NotEqual(0, saleItem.UnitPrice);
            Assert.Equal(0, saleItem.Discount);
            Assert.Null(saleItem.Product);
            Assert.Null(saleItem.Sale);
        }
    }
}
