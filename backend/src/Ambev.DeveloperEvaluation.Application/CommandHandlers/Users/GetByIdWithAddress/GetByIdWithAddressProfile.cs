using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdWithAddress;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class GetByIdWithAddressProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public GetByIdWithAddressProfile()
    {
        CreateMap<User, GetByIdWithAddressResult>();
        CreateMap<NameVo, GetByIdWithAddressNameDto>();
        CreateMap<Address, GetByIdWithAddressAddressDto>();
        CreateMap<GeoLocation, GetByIdWithAddressGeolocationDto>();
    }
}
