namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequest
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Caregory { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public UpdateProductRatingRequest Rating { get; set; } = new UpdateProductRatingRequest();
    }
}
