namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart
{
    public class GetRangeCartResponse
    {
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public IList<GetRangeCartItemResponse> Products { get; set; } = new List<GetRangeCartItemResponse>();
    }
}
