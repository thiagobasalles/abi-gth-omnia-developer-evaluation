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
    /// Contains unit tests for the Sale entity class.
    /// </summary>
    public class SaleTests
    {
        /// <summary>
        /// Tests that a sale can be approved if it has been pre-approved and not yet approved or cancelled.
        /// </summary>
        [Fact(DisplayName = "Approve should set DateApproved if pre-approved and not approved or cancelled")]
        public void Given_PreApprovedSale_When_Approve_Then_DateApprovedIsSet()
        {
            var sale = SaleTestData.GenerateValidSale();
            sale.SetPreApproveSale(SaleTestData.GenerateBranchId());

            sale.Approve();

            Assert.NotNull(sale.DateApproved);
            Assert.Null(sale.DateCancelled);
        }

        /// <summary>
        /// Tests that Approve throws a DomainException if the sale has already been cancelled.
        /// </summary>
        [Fact(DisplayName = "Approve should throw DomainException if sale is cancelled")]
        public void Given_CancelledSale_When_Approve_Then_ThrowsDomainException()
        {
            var sale = SaleTestData.GenerateValidCancelledSale();
            sale.SetPreApproveSale(SaleTestData.GenerateBranchId());

            Assert.Throws<DomainException>(() => sale.SetPreApproveSale(SaleTestData.GenerateBranchId()));
        }


        /// <summary>
        /// Tests that Approve throws a DomainException if the sale has not been pre-approved.
        /// </summary>
        [Fact(DisplayName = "Approve should throw DomainException if sale is not pre-approved")]
        public void Given_NotPreApprovedSale_When_Approve_Then_ThrowsDomainException()
        {
            var sale = SaleTestData.GenerateValidSale();

            Assert.Throws<DomainException>(() => sale.Approve());
        }

        /// <summary>
        /// Tests that a sale can be cancelled if it has not been cancelled before.
        /// </summary>
        [Fact(DisplayName = "Cancel should set DateCancelled if not already cancelled")]
        public void Given_NotCancelledSale_When_Cancel_Then_DateCancelledIsSet()
        {
            var sale = SaleTestData.GenerateValidSale();

            sale.Cancel();

            Assert.NotNull(sale.DateCancelled);
        }

        /// <summary>
        /// Tests that Cancel throws a DomainException if the sale has already been cancelled.
        /// </summary>
        [Fact(DisplayName = "Cancel should throw DomainException if sale is already cancelled")]
        public void Given_CancelledSale_When_Cancel_Then_ThrowsDomainException()
        {
            var sale = SaleTestData.GenerateValidSale();
            sale.Cancel();

            Assert.Throws<DomainException>(() => sale.Cancel());
        }
    }
}
