using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.Application.Users.GetPaginatedUsers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetPaginatedUsers;

/// <summary>
/// Profile for mapping GetPaginatedUsers feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetPaginatedUsers feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<GetPaginatedUsersRequest, GetPaginatedUsersCommand>();
        CreateMap<GetPaginatedUsersResult, GetByIdWithAddressResponse>();
        CreateMap<GetPaginatedUsersAddressDto, GetByIdWithAddressAddressResponse>();
        CreateMap<GetPaginatedUsersNameDto, GetByIdWithAddressNameResponse>();
        CreateMap<GetPaginatedUsersGeolocationDto, GetByIdWithAddressGeolocationResponse>();

    }
}
