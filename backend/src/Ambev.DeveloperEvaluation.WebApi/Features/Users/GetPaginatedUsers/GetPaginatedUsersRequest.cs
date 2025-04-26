namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetPaginatedUsers;

/// <summary>
/// Rating model for getting a user by ID
/// </summary>
public class GetPaginatedUsersRequest
{
    /// <summary>
    /// The page request
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// The size of page request
    /// </summary>
    public int Size { get; set; }
    /// <summary>
    /// The order of page request
    /// </summary>
    public string Order { get; set; } = string.Empty;
}
