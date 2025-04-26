namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart
{
    public class CreateUpdateCartResponse
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public IList<CreateUpdateCartItemResponse>? Products { get; set; } = new List<CreateUpdateCartItemResponse>();
    }

}
