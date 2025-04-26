using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart
{
    public class GetRangeCartProfile : Profile
    {
        public GetRangeCartProfile() 
        {
            CreateMap<Cart, GetRangeCartResult>();
        }
    }
}
