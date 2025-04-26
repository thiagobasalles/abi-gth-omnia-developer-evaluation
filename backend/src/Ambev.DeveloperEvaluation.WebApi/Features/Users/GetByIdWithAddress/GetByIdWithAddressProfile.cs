using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress;
using Ambev.DeveloperEvaluation.Application.Users.GetByIdWithAddress;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressProfile : Profile
    {
        public GetByIdWithAddressProfile()
        {
            CreateMap<GetByIdWithAddressRequest, GetByIdWithAddressCommand>();

            CreateMap<GetByIdWithAddressResult, GetByIdWithAddressResponse>().ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<GetByIdWithAddressNameDto, GetByIdWithAddressNameResponse>();
            CreateMap<GetByIdWithAddressAddressDto, GetByIdWithAddressAddressResponse>();
            CreateMap<GetByIdWithAddressGeolocationDto, GetByIdWithAddressGeolocationResponse>();
        }
    }
}
