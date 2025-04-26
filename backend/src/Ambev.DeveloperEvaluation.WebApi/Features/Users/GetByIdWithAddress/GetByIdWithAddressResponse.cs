using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class GetByIdWithAddressResponse
{
    /// <summary>
    /// The unique identifier of the created user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The username of user
    /// </summary>
    public string Username{ get; set; } = string.Empty;

    /// <summary>
    /// The user's First and Last name.
    /// </summary>
    public GetByIdWithAddressNameResponse Name { get; set; } = new GetByIdWithAddressNameResponse();

    /// <summary>
    /// The user's password.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    public GetByIdWithAddressAddressResponse Address { get; set; } = new GetByIdWithAddressAddressResponse();

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public UserStatus Status { get; set; }
}
