using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntityLongId
    {
        public Guid UserId { get; set; }
        public long BranchId { get; set; }
        public DateTime? DatePreApprove { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateCancelled { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<SaleItem>? SaleItems { get; set; }
        public User? User { get; set; }
        public Branch? Branch { get; set; }

        public void Approve()
        {
            if (DateCancelled != null)
                throw new DomainException($"This sale cannot be approved because it has already been cancelled on {DateCancelled.Value.ToString("dd/MM/yyyy HH:mm:ss")}.");

            if (DateApproved != null)
                throw new DomainException($"This sale cannot be approved because it has already been approved on {DateApproved.Value.ToString("dd/MM/yyyy HH:mm:ss")}.");

            if (DatePreApprove == null)
                throw new DomainException($"This sale cannot be approved because it has not been pre-approved.");

            this.DateApproved = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (DateCancelled!=null)
                throw new DomainException($"This sale cannot be cancelled because it has already been cancelled on {DateCancelled.Value.ToString("dd/MM/yyyy HH:mm:ss")}");

            DateCancelled = DateTime.UtcNow;
        }

        public void SetPreApproveSale(long branchId)
        {
            if (DatePreApprove != null)
                throw new DomainException($"This sale has been pre-approved.");

            this.BranchId = branchId;
            DatePreApprove = DateTime.UtcNow;
        }
    }
}
