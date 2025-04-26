
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PreApprove
{
    public class PreApproveResponse
    {
        public long CartId { get; set; }
        public Guid UserId { get; set; }
        public long BranchId { get; set; }
        public long SaleId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<PreApproveItemResponse> Products { get; set; } = new List<PreApproveItemResponse>();
    }
}
