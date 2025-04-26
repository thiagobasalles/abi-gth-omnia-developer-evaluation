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

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.CreateCart
{
    public class CreateUpdateCartHandler : IRequestHandler<CreateUpdateCartCommand, CreateUpdateCartResult>
    {
        private readonly ICartCacheService _cartCacheService;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateUpdateCartHandler(
            ICartCacheService cartCacheService, 
            IMapper mapper,
            IProductRepository productRepository) 
        {
            _cartCacheService = cartCacheService;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<CreateUpdateCartResult> Handle(CreateUpdateCartCommand request, CancellationToken cancellationToken)
        {
            var commandValidator = new CreateUpdateCartValidator();
            var validationResult = commandValidator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            

            var cart = _mapper.Map<Cart>(request);

            await PopulitePriceAsync(cart);

            cart.ApplyDiscountsAndCalculateTotal();

            cart = await _cartCacheService.AddASync(cart);

            var result = _mapper.Map<CreateUpdateCartResult>(cart);

            return result;
        }

        private async Task PopulitePriceAsync(Cart cart)
        {
            foreach (CartItem product in cart.Products)
            {
                var productDb = await _productRepository.GetByIdWithRatingAsync(product.ProductId) ?? throw new KeyNotFoundException($"Product id {product.ProductId} not found");
                product.UnitPrice = productDb.Price;
            }
        }
    }
}
