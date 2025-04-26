using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Domain.Caches;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetangeCart
{
    public class GetRangeCartHandler : IRequestHandler<GetRangeCartCommand, IQueryable<GetRangeCartResult>>
    {
        private readonly ICartCacheService _cartCacheService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetRangeCartHandler(ICartCacheService cartCacheService, IProductRepository productRepository, IMapper mapper)
        {
            _cartCacheService = cartCacheService;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IQueryable<GetRangeCartResult>> Handle(GetRangeCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartCacheService.GetQueryableAsync();

            var cartResultQuerable = cart.ProjectTo<GetRangeCartResult>(_mapper.ConfigurationProvider);

            return cartResultQuerable;
        }
    }
}
