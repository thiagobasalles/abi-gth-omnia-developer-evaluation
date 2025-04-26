using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;

/// <summary>
/// Command for creating a new user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a user, 
/// including username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateUserCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets the ID of user.
    /// </summary>
    public Guid Id { get; }
    /// <summary>
    /// Gets or sets the username of the user to be created.
    /// </summary>
    public string Username { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of user.
    /// </summary>
    public UpdateUserNameDto Name {  get; } = new UpdateUserNameDto();

    /// <summary>
    /// Gets or sets the password for the user.
    /// </summary>
    public string Password { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the user.
    /// </summary>
    public string Phone { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address for the user.
    /// </summary>
    public string Email { get; } = string.Empty;

    public UpdateUserAddressDto Address { get; } = new UpdateUserAddressDto();

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; }

    public UpdateUserCommand(
        Guid id,
        string username,
        string password,
        string phone,
        string email,
        UpdateUserNameDto name,
        UpdateUserAddressDto address,
        UserStatus status,
        UserRole role)
    {
        Id = id;
        Username = username;
        Password = password;
        Phone = phone;
        Email = email;
        Name = name;
        Address = address;
        Status = status;
        Role = role;
    }


    public ValidationResultDetail Validate()
    {
        var validator = new UpdateUserCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}