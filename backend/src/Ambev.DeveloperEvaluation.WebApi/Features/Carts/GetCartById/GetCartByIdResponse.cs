namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{
    public class GetCartByIdResponse
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public IList<GetCartByIdItemResponse> Products { get; set; } = new List<GetCartByIdItemResponse>();
    }
}
