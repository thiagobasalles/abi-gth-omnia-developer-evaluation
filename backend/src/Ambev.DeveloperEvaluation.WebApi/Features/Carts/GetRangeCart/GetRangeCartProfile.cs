using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetRangeCart
{
    public class GetRangeCartProfile : Profile
    {
        public GetRangeCartProfile() 
        {
            CreateMap<GetRangeCartRequest, GetRangeCartCommand>();
        }
    }
}
