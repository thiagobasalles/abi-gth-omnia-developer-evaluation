using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove
{
    public class PreApproveResult
    {
        public long CartId { get; set; }
        public Guid UserId { get; set; }
        public long BranchId { get; set; }
        public long SaleId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<PreApproveItemResult> Products { get; set; } = new List<PreApproveItemResult>();
    }
}
