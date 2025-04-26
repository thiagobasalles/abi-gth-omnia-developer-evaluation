using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Caches;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById
{
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdCommand, GetCartByIdResult>
    {

        private readonly ICartCacheService _cartCacheService;
        private readonly IMapper _mapper;

        public GetCartByIdHandler(ICartCacheService cartCacheService, IMapper mapper)
        {
            _cartCacheService = cartCacheService;
            _mapper = mapper;
        }
        public async Task<GetCartByIdResult> Handle(GetCartByIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetCartByIdValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            Cart? cart = await _cartCacheService.GetCartByIdAsync(request.Id);
            if(cart == null)
                throw new KeyNotFoundException($"Cart with ID {request.Id} not found");
            
            var getCartByIdresult = _mapper.Map<GetCartByIdResult>(cart);

            

            return getCartByIdresult;

        }

    }
}
