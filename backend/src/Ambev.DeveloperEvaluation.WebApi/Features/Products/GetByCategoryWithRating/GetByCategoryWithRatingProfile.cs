using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingProfile : Profile
    {
        public GetByCategoryWithRatingProfile()
        {
            CreateMap<GetByCategoryWithRatingRequest, GetByCategoryWithRatingCommand>();

            CreateMap<GetByCategoryWithRatingResult, GetByIdWithRatingResponse>();
            CreateMap<GetByCategoryWithRatingRatingResult, GetByIdWithRatingRatingResponse>();
        }
    }
}
