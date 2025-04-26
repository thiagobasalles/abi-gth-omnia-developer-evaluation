using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<CreateUserNameDto, NameVo>();
        CreateMap<CreateUserAddressDto, Address>();
        CreateMap<CreateUserGeolocationDto, GeoLocation>();
    }
}
