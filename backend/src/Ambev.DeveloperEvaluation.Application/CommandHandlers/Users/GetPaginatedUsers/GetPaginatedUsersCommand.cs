using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;

/// <summary>
/// Command for retrieving a IQueryable user
/// </summary>
public record GetPaginatedUsersCommand : IRequest<IQueryable<GetPaginatedUsersResult>>
{
    /// <summary>
    /// Gets order to paginate
    /// </summary>
    public string Order { get; }

    /// <summary>
    /// Initializes a new instance of GetPaginatedUsersCommand
    /// </summary>
    public GetPaginatedUsersCommand(string order)
    {
        Order = order;
    }
}
