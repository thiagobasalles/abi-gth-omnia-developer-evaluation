namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Rating model for deleting a user
/// </summary>
public class DeleteProductRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public long Id { get; set; }
}
