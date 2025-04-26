using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{
    public class GetCartByIdProfile : Profile
    {
        public GetCartByIdProfile()
        {
            CreateMap<GetCartByIdRequest, GetCartByIdCommand>();

            CreateMap<GetCartByIdResult, GetCartByIdResponse>();
            CreateMap<GetCartByIdItemResult, GetCartByIdItemResponse>();
        }
    }
}
