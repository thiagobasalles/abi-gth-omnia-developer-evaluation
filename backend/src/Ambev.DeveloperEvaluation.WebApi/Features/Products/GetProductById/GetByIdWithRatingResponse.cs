namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById
{
    public class GetByIdWithRatingResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public GetByIdWithRatingRatingResponse Rating { get; set; } = default!;
    }
}
