using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetPaginatedProducts
{
    public class GetPaginatedProductsProfile : Profile
    {
        public GetPaginatedProductsProfile() 
        {
            CreateMap<Product, GetPaginatedProductsResult>();
            CreateMap<Rating, GetPaginatedProductsRatingResult>();
        }
    }
}
