namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

/// <summary>
/// Rating model for deleting a user
/// </summary>
public class DeleteUserRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
