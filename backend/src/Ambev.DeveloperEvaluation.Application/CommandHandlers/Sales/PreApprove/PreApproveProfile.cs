using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove
{
    public class PreApproveProfile : Profile
    {
        public PreApproveProfile()
        {
            CreateMap<Cart, Sale>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.Products))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CartItem, SaleItem>();

            CreateMap<Sale, PreApproveResult>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));

            CreateMap<SaleItem, PreApproveItemResult>();
        }
    }
}
