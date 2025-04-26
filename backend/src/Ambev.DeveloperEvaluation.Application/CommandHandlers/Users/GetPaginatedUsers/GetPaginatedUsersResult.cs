using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class GetPaginatedUsersResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created user in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// The username of user
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of user.
    /// </summary>
    public GetPaginatedUsersNameDto Name { get; set; } = new GetPaginatedUsersNameDto();

    /// <summary>
    /// Gets or sets the password for the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the user.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address for the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    public GetPaginatedUsersAddressDto Address { get; set; } = new GetPaginatedUsersAddressDto();

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; set; }
}
