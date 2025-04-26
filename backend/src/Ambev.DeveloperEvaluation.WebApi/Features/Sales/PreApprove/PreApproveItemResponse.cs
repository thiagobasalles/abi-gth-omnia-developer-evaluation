namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PreApprove
{
    public class PreApproveItemResponse
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
