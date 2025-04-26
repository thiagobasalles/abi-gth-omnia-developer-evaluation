using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating
{
    public class GetByIdWithRatingProfile : Profile
    {
        public GetByIdWithRatingProfile() 
        {
            CreateMap<Product, GetByIdWithRatingResult>();
            CreateMap<Rating, GetByIdWithRatingRatingResult>();
        }
    }
}
