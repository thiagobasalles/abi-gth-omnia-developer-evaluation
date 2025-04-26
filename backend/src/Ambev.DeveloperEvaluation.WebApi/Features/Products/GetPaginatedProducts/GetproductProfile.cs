using Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetPaginatedProducts
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile() 
        {
            CreateMap<GetPaginatedProductsRequest, GetPaginatedProductsCommand>();

            CreateMap<GetPaginatedProductsResult, GetByIdWithRatingResponse>();
            CreateMap<GetPaginatedProductsRatingResult, GetByIdWithRatingRatingResponse>();
            
        }
    }
}
