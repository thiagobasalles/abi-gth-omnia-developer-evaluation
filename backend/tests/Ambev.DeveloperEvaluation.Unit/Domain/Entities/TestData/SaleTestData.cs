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
    /// Provides methods for generating test data for the Sale and SaleItem entities using the Bogus library.
    /// </summary>
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleValidToApproveFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Long(1, 100))
            .RuleFor(s => s.UserId, f => f.Random.Guid())
            .RuleFor(s => s.BranchId, f => f.Random.Long(1, 10))
            .RuleFor(s => s.DatePreApprove, (DateTime?)null)
            .RuleFor(s => s.DateApproved, (DateTime?)null)
            .RuleFor(s => s.DateCancelled, (DateTime?) null)
            .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(10, 1000))
            .RuleFor(s => s.SaleItems, (Faker f) => GenerateValidSaleItems(f.Random.Number(1, 3)))
            .RuleFor(s => s.User, (Faker f) => UserTestData.GenerateValidUser())
            .RuleFor(s => s.Branch, (Faker f) => GenerateValidBranch());

        private static readonly Faker<Sale> SaleValidCancelledFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Long(1, 100))
            .RuleFor(s => s.UserId, f => f.Random.Guid())
            .RuleFor(s => s.BranchId, f => f.Random.Long(1, 10))
            .RuleFor(s => s.DatePreApprove, (DateTime?)null)
            .RuleFor(s => s.DateApproved, (DateTime?)null)
            .RuleFor(s => s.DateCancelled, DateTime.UtcNow)
            .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(10, 1000))
            .RuleFor(s => s.SaleItems, (Faker f) => GenerateValidSaleItems(f.Random.Number(1, 3)))
            .RuleFor(s => s.User, (Faker f) => UserTestData.GenerateValidUser())
            .RuleFor(s => s.Branch, (Faker f) => GenerateValidBranch());

        private static readonly Faker<Sale> SaleValidoNotPreApprovedFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Long(1, 100))
            .RuleFor(s => s.UserId, f => f.Random.Guid())
            .RuleFor(s => s.BranchId, f => f.Random.Long(1, 10))
            .RuleFor(s => s.DatePreApprove, (DateTime?)null)
            .RuleFor(s => s.DateApproved, DateTime.UtcNow)
            .RuleFor(s => s.DateCancelled, (DateTime?)null)
            .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(10, 1000))
            .RuleFor(s => s.SaleItems, (Faker f) => GenerateValidSaleItems(f.Random.Number(1, 3)))
            .RuleFor(s => s.User, (Faker f) => UserTestData.GenerateValidUser())
            .RuleFor(s => s.Branch, (Faker f) => GenerateValidBranch());

        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .RuleFor(si => si.Id, f => f.Random.Long(1, 100))
            .RuleFor(si => si.SaleId, f => f.Random.Long(1, 100))
            .RuleFor(si => si.ProductId, f => f.Random.Long(1, 100))
            .RuleFor(si => si.Quantity, f => f.Random.Number(1, 10))
            .RuleFor(si => si.UnitPrice, f => f.Random.Decimal(1, 100))
            .RuleFor(si => si.Discount, f => f.Random.Decimal(0, 10));


        /// <summary>
        /// Generates a approved Sale.
        /// </summary>
        public static Sale GenerateValidNotPreApprovedSale()
        {
            return SaleValidoNotPreApprovedFaker.Generate();
        }

        /// <summary>
        /// Generates a Cancelled Sale.
        /// </summary>
        public static Sale GenerateValidCancelledSale()
        {
            return SaleValidCancelledFaker.Generate();
        }

        /// <summary>
        /// Generates a valid Sale entity to approved.
        /// </summary>
        public static Sale GenerateValidSale()
        {
            return SaleValidToApproveFaker.Generate();
        }

        /// <summary>
        /// Generates a valid SaleItem entity with randomized data.
        /// </summary>
        public static SaleItem GenerateValidSaleItem()
        {
            return SaleItemFaker.Generate();
        }

        /// <summary>
        /// Generates a list of valid SaleItem entities with a specified number of items.
        /// </summary>
        /// <param name="count">The number of SaleItem entities to generate.</param>
        public static List<SaleItem> GenerateValidSaleItems(int count)
        {
            return SaleItemFaker.Generate(count);
        }

        /// <summary>
        /// Generates a valid Branch entity for testing purposes.
        /// </summary>
        public static Branch GenerateValidBranch()
        {
            return new Faker<Branch>()
                .RuleFor(b => b.Id, f => f.Random.Long(1, 10))
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .Generate();
        }

        /// <summary>
        /// Generates a valid BranchId for testing purposes.
        /// </summary>
        public static long GenerateBranchId()
        {
            return new Faker().Random.Long(1, 10);
        }

    }
}
