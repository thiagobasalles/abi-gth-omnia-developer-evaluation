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

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove
{
    public class PreApproveHandler : IRequestHandler<PreApproveCommand, PreApproveResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICartCacheService _cartCacheService;
        private readonly IMapper _mapper;
        public PreApproveHandler(
            ISaleRepository saleRepository, 
            ICartCacheService cartCacheService,
            IMapper mapper
            )
        {
            _saleRepository = saleRepository;
            _cartCacheService = cartCacheService;
            _mapper = mapper;
        }

        public async Task<PreApproveResult> Handle(PreApproveCommand request, CancellationToken cancellationToken)
        {
            var validator = new PreApproveValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            Cart cart = await _cartCacheService.GetCartByIdAsync(request.CartId) ?? throw new KeyNotFoundException("Cart id cannot find");

            var sale = _mapper.Map<Sale>(cart);
            sale.SetPreApproveSale(request.BranchId);

            sale = await _saleRepository.CreateAsync(sale);

            var result = _mapper.Map<PreApproveResult>(sale);
            return result;
        }
    }
}
