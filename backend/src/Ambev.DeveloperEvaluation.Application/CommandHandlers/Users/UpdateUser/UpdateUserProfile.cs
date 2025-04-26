using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class UpdateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserCommand, User>();
        CreateMap<UpdateUserNameDto, NameVo>();
        CreateMap<UpdateUserAddressDto, Address>();
        CreateMap<UpdateUserGeolocationDto, GeoLocation>();
    }
}
