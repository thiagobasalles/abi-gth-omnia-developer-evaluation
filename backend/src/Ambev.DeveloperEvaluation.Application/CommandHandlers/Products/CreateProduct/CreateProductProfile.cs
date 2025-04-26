using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.CreateProduct
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile() 
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateProductRatingDto, Rating>();
        }
    }
}
