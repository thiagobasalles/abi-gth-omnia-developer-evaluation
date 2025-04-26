using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdWithAddress;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class GetByIdWithAddressResult
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
    public GetByIdWithAddressNameDto Name { get; set; } = new GetByIdWithAddressNameDto();

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

    public GetByIdWithAddressAddressDto Address { get; set; } = new GetByIdWithAddressAddressDto();

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; set; }
}
