using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Caches;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.DeleteCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly ICartCacheService _cartCacheService;
        private readonly IMapper _mapper;
        public DeleteCartHandler(ICartCacheService cartCacheService, IMapper mapper)
        {
            _cartCacheService = cartCacheService;
            _mapper = mapper;
        }

        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            await _cartCacheService.Delete(request.Id);
            return;
        }
    }
}
