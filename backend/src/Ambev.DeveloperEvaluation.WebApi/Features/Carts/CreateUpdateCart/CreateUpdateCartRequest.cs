namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart
{
    public class CreateUpdateCartRequest
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public IList<CreateUpdateCartItemRequest> Products { get; set; } =  new List<CreateUpdateCartItemRequest>();

    }
}
