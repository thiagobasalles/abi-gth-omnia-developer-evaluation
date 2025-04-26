using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart
{
    public class CreateUpdateCartProfile : Profile
    {
        public CreateUpdateCartProfile() {
            CreateMap<CreateUpdateCartCommand, Cart>();
            CreateMap<CreateUpdateCartItemDto, CartItem>();

            CreateMap<Cart, CreateUpdateCartResult>();
            CreateMap<CartItem, CreateUpdateCartItemDto>();
        }
    }
}
