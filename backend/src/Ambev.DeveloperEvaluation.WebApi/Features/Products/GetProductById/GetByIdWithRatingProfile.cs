using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById
{
    public class GetByIdWithRatingProfile : Profile
    {
        public GetByIdWithRatingProfile()
        {
            CreateMap<GetByIdWithRatingRequest, GetByIdWithRatingCommand>();

            CreateMap<GetByIdWithRatingResult, GetByIdWithRatingResponse>();
            CreateMap<GetByIdWithRatingRatingResult, GetByIdWithRatingRatingResponse>();
        }
    }
}
