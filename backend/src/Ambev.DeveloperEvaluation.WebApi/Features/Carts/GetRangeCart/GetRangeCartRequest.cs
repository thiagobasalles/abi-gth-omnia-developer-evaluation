namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart
{
    public class GetRangeCartRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Order {  get; set; } = string.Empty;
    }
}
