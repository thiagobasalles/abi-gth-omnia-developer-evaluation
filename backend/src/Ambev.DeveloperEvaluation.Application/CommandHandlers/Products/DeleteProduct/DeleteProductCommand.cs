using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.DeleteProduct;

/// <summary>
/// Command for deleting a Product
/// </summary>
public record DeleteProductCommand : IRequest<DeleteProductResponse>
{
    /// <summary>
    /// The unique identifier of the Product to delete
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProductCommand
    /// </summary>
    /// <param name="id">The ID of the Product to delete</param>
    public DeleteProductCommand(long id)
    {
        Id = id;
    }
}
