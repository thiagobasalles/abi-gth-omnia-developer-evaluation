using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetPaginatedUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetPaginatedUsers operation
    /// </summary>
    public GetPaginatedUsersProfile()
    {
        CreateMap<User, GetPaginatedUsersResult>();
        CreateMap<Address, GetPaginatedUsersAddressDto>();
        CreateMap<NameVo, GetPaginatedUsersNameDto>();
        CreateMap<GeoLocation, GetPaginatedUsersGeolocationDto>();
    }
}
