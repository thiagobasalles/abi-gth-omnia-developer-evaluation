using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById
{
    public class GetCartByIdProfile : Profile
    {
        public GetCartByIdProfile()
        {
            CreateMap<Cart, GetCartByIdResult>();
            CreateMap<CartItem, GetCartByIdItemResult>();

            CreateMap<GetCartByIdResult, Cart>();
            CreateMap<GetCartByIdItemResult, CartItem>();
        }
    }
}
