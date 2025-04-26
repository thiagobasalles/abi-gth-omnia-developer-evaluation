namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingRequest
    {
        public string Category { get; set; } = string.Empty;
        public int Page { get; set; }
        public int Size { get; set; }
        public string Order { get; set; } = string.Empty;
    }
}
