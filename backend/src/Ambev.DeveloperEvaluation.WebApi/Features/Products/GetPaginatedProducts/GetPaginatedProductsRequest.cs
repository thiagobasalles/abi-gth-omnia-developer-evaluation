namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetPaginatedProducts
{
    public class GetPaginatedProductsRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Order { get; set; } = string.Empty;
    }
}
