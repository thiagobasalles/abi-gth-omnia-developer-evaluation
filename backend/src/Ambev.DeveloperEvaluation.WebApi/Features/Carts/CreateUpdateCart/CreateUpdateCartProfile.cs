using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateUpdateCart
{
    public class CreateUpdateCartProfile : Profile
    {
        public CreateUpdateCartProfile()
        {
            CreateMap<CreateUpdateCartRequest, CreateUpdateCartCommand>();

            CreateMap<CreateUpdateCartItemRequest, CreateUpdateCartItemDto>();

            CreateMap<CreateUpdateCartResult, CreateUpdateCartResponse>();
            CreateMap<CreateUpdateCartItemDto, CreateUpdateCartItemResponse>();
        }
    }
}
