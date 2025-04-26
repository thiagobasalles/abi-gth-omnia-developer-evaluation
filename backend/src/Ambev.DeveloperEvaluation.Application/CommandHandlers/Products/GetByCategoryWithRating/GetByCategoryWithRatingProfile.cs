using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByCategoryWithRating
{
    public class GetByCategoryWithRatingProfile : Profile
    {
        public GetByCategoryWithRatingProfile() 
        {
            CreateMap<Product, GetByCategoryWithRatingResult>();
            CreateMap<Rating, GetByCategoryWithRatingRatingResult>();
        }
    }
}
