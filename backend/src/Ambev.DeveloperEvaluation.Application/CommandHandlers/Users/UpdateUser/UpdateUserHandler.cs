using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private IGeoApiService _geoApiService;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public UpdateUserHandler(IUserRepository userRepository, 
        IMapper mapper, 
        IPasswordHasher passwordHasher,
        IGeoApiService geoApiService
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _geoApiService = geoApiService;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<Guid> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userDb = await _userRepository.GetByIdWithAddressAsync(command.Id, cancellationToken);
        if (userDb == null)
            throw new InvalidOperationException($"User with ID {command.Id} not exists");

        var resultGeolocation = await _geoApiService.GetByAddress(command.Address.ToString());

        var user = _mapper.Map(command, userDb);
        user.Password = _passwordHasher.HashPassword(command.Password);
        (user.Address ?? throw new InvalidOperationException("Address cannot be null."))
            .Geolocation = GeoLocation.AddLatLong(resultGeolocation.Lat, resultGeolocation.Lon);

        await _userRepository.UpdateAsync(user, cancellationToken);
        return user.Id;
    }
}
