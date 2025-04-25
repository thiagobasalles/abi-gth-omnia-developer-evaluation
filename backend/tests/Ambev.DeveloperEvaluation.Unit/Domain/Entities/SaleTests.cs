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
            var sale = SaleTestData.GenerateValidSale();
            sale.SetPreApproveSale(SaleTestData.GenerateBranchId());
            sale.Cancel();

            Assert.Throws<DomainException>(() => sale.Approve());
        }

        /// <summary>
        /// Tests that Approve throws a DomainException if the sale has already been approved.
        /// </summary>
        [Fact(DisplayName = "Approve should throw DomainException if sale is already approved")]
        public void Given_ApprovedSale_When_Approve_Then_ThrowsDomainException()
        {
            var sale = SaleTestData.GenerateValidSale();
            sale.SetPreApproveSale(SaleTestData.GenerateBranchId());
            sale.Approve();

            Assert.Throws<DomainException>(() => sale.Approve());
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

        /// <summary>
        /// Tests that SetPreApproveSale sets the DatePreApprove and BranchId if not already pre-approved.
        /// </summary>
        [Fact(DisplayName = "SetPreApproveSale should set DatePreApprove and BranchId if not pre-approved")]
        public void Given_NotPreApprovedSale_When_SetPreApproveSale_Then_DatePreApproveAndBranchIdAreSet()
        {
            var sale = SaleTestData.GenerateValidSale();
            var branchId = SaleTestData.GenerateBranchId();

            sale.SetPreApproveSale(branchId);

            Assert.NotNull(sale.DatePreApprove);
            Assert.Equal(branchId, sale.BranchId);
        }

        /// <summary>
        /// Tests that SetPreApproveSale throws a DomainException if the sale has already been pre-approved.
        /// </summary>
        [Fact(DisplayName = "SetPreApproveSale should throw DomainException if already pre-approved")]
        public void Given_PreApprovedSale_When_SetPreApproveSale_Then_ThrowsDomainException()
        {
            var sale = SaleTestData.GenerateValidSale();
            sale.SetPreApproveSale(SaleTestData.GenerateBranchId());

            Assert.Throws<DomainException>(() => sale.SetPreApproveSale(SaleTestData.GenerateDifferentBranchId()));
        }
    }
}
